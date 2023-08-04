import { Component } from '@angular/core';
import { FormGroup,FormControl  } from '@angular/forms';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, observable } from 'rxjs';
import { BooksService } from 'src/app/Environment/books.service';
import { IBook } from 'src/app/Interfaces/ibook';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent {
  constructor(private _Router: Router, private _BooksService: BooksService) { }
  Books: IBook[] = [];
  filtersGroup = new FormGroup({
    ISBN13 : new FormControl<number|string>(""),
    Author : new FormControl<string>(""),
    Category : new FormControl<string>(""),
    Title : new FormControl<string>(""),
    MinPrice : new FormControl<number>(0),
    MaxPrice : new FormControl<number>(500),
    PageIndex : new FormControl<number>(1),
})
  currentPageIndex: number = 1;
  TotalPages: number = 0;
  TotalCount = 0;
  page_numbers: number[] = [];
  Categories: string[] = [];
  IsSearchResultsViewed:boolean = false;
  SelectedOption = new BehaviorSubject<string>("");
  searchValue = new BehaviorSubject<string>("");
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.getBooks(1);
    this.current_page_check();
    this.getAllCategories();
    this.selectedOptionChecker();
    this.SearchBarValueSubscriber();
    this.priceSliderFrom();
    this.priceSliderTo();
  }
  //Paginator Design
  current_page_check() {
    if (this.currentPageIndex == 1) {
      this.page_numbers = [this.currentPageIndex, Number((this.currentPageIndex)) + 1, Number((this.currentPageIndex)) + 2]
    }
    else if (this.currentPageIndex == 2) {
      this.page_numbers = [Number((this.currentPageIndex)) - 1, this.currentPageIndex, Number((this.currentPageIndex)) + 1, Number((this.currentPageIndex)) + 2]
    }
    else if (this.currentPageIndex == 3) {
      this.page_numbers = [Number((this.currentPageIndex)) - 2, Number((this.currentPageIndex)) - 1, this.currentPageIndex, Number((this.currentPageIndex)) + 1, Number((this.currentPageIndex)) + 2]
    }
    else if (this.currentPageIndex == this.TotalPages) {
      this.page_numbers = [Number((this.currentPageIndex)) - 4, Number((this.currentPageIndex)) - 3, Number((this.currentPageIndex)) - 2, Number((this.currentPageIndex)) - 1, this.currentPageIndex]
    }
    else if (Number(this.currentPageIndex) == Number(this.TotalPages - 1)) {
      this.page_numbers = [Number((this.currentPageIndex)) - 3, Number((this.currentPageIndex)) - 2, Number((this.currentPageIndex)) - 1, this.currentPageIndex, Number((this.currentPageIndex)) + 1]
    }
    else if (Number(this.currentPageIndex) == Number(this.TotalPages - 2)) {
      this.page_numbers = [Number((this.currentPageIndex)) - 2, Number((this.currentPageIndex)) - 1, Number((this.currentPageIndex)), this.currentPageIndex + 1, Number((this.currentPageIndex)) + 2]
    }
    else {
      this.page_numbers = [this.currentPageIndex - 2, this.currentPageIndex - 1, this.currentPageIndex, Number((this.currentPageIndex)) + 1, Number((this.currentPageIndex)) + 2]
    }
  }
  async PageandPaginationUpdate(index: number) {
    this.currentPageIndex = index;
    await this.getBooks(index);
    await this.current_page_check();
  }
  //Get Data From Apis
  getBooks(pageindex: number) {
    this._BooksService.getAllBooks(pageindex).subscribe(response => {
      this.Books = response.data;
      this.TotalCount = response.count;
      this.TotalPages = response.count / 20;
    });
  }
  getBooksWithSort(pageindex: number, sort: string) {
    this._BooksService.getAllBooksWithSort(pageindex, sort).subscribe(response => {
      this.Books = response.data;
      this.TotalPages = response.count;
    });
  }
  getBooksWithSearch(pageindex: number, search: string) {
    this._BooksService.getAllBooksWithSearch(pageindex, search).subscribe(response => {
      this.Books = response.data;
      this.TotalCount = response.count;
    });
    this.current_page_check();
  }
  getAllCategories() {
    this._BooksService.getAllCategories().subscribe(res => {
      this.Categories = res;
    })
  }
  //Order by select Options Functions
  getSelectedoption(option: string) {
    this.SelectedOption.next(option);
  };
  selectedOptionChecker(){
    this.SelectedOption.subscribe(value => {
      if (this.SelectedOption.getValue() == "Title Ascending") {
        this.getBooksWithSort(1, "titleAsc")
      }
      else if (this.SelectedOption.getValue() == "Title Descending") {
        this.getBooksWithSort(1, "titleDesc")
      }
      else if (this.SelectedOption.getValue() == "Price Ascending") {
        this.getBooksWithSort(1, "priceAsc")
      }
      else if (this.SelectedOption.getValue() == "Price Descending") {
        this.getBooksWithSort(1, "priceDesc")
      }
    })
  }
  //Search Bar Function
  getSearchValue(event: any) {
    this.searchValue.next(event.target.value);
  }
  SearchBarValueSubscriber(){
    this.searchValue.subscribe(value => {
      if (this.searchValue.getValue() != "") {
        this.IsSearchResultsViewed = true;
        this.getBooksWithSearch(1, this.searchValue.getValue())
      }
    })
  }
  //Price Sliders 
  priceSliderFrom(){
    var outputfrom = document.getElementById('from');
    const sliderfrom = <HTMLInputElement>document.getElementById("fromRange");
    if (outputfrom) outputfrom.innerHTML = sliderfrom.value;// Display the default slider value
    // Update the current slider value (each time you drag the slider handle)
    sliderfrom.oninput = function () {
      if (outputfrom) outputfrom.innerHTML = sliderfrom.value;
    }
  }
  priceSliderTo(){
    var outputTo = document.getElementById('to');
    const sliderTo = <HTMLInputElement>document.getElementById("toRange");
    if (outputTo) outputTo.innerHTML = sliderTo.value;// Display the default slider value
    // Update the current slider value (each time you drag the slider handle)
    sliderTo.oninput = function () {
      if (outputTo){
        outputTo.innerHTML = sliderTo.value;
        console.log(sliderTo.value)
      } 
    }
  }
  //Setting Form Data To Send It As Query Params to Search
  setFilterISBN(number:string){
    this.filtersGroup.controls['ISBN13'].setValue(Number(number))
  }
  setFilterAuthor(name:string){
    this.filtersGroup.controls['Author'].setValue(name)
  }
  setFilterCategory(category:string){
    this.filtersGroup.controls['Category'].setValue(category != "Select Category"?category:"")
  }
  setFilterTitle(title:string){
    this.filtersGroup.controls['Title'].setValue(title)
  }
  setFilterMinPrice(MinPrice:string){
    this.filtersGroup.controls['MinPrice'].setValue(Number(MinPrice))
  }
  setFilterMaxPrice(MaxPrice:string){
    this.filtersGroup.controls['MaxPrice'].setValue(Number(MaxPrice))
  }
  //submitting form and navigate to Filter Page
  SubmitFilter(FormGroup:FormGroup){
      this._Router.navigate(["search"], {
        queryParams: {
          ISBN13:  this.filtersGroup.controls['ISBN13'].value,
          Author: this.filtersGroup.controls['Author'].value,
          Category: this.filtersGroup.controls['Category'].value,
          Title: this.filtersGroup.controls['Title'].value,
          MinPrice: this.filtersGroup.controls['MinPrice'].value,
          MaxPrice: this.filtersGroup.controls['MaxPrice'].value,
          PageIndex: this.filtersGroup.controls['PageIndex'].value,
        },
        queryParamsHandling: 'merge',
      });
  }
  navigateToTop(){
    window.scrollTo(0, 0);
  }
}
