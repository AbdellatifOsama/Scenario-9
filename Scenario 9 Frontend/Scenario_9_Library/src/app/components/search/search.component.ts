import { Component } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { BooksService } from 'src/app/Environment/books.service';
import { FilterParams } from 'src/app/Interfaces/filter-params';
import { IBook } from 'src/app/Interfaces/ibook';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent {
constructor(private BooksService:BooksService,private _activatedRoute: ActivatedRoute) {
}
Books:IBook[]=[];
currentPageIndex: number = 1;
TotalPages: number = 0;
TotalCount = 0;
isTotlaCountsLess20 = false;
page_numbers: number[] = [];
ngOnInit(): void {
  this.PageandPaginationUpdate(1);
  //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
  //Add 'implements OnInit' to the class.
  // this.Books = this.BooksService.FilteredData;
  // this._activatedRoute.queryParams.subscribe(
  //   params => console.log('queryParams', params));
}
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
  let temp:any = JSON.parse(JSON.stringify(this._activatedRoute.snapshot.queryParams)) ;
  temp.PageIndex = index;
  this.getFilteredData(temp);
  await this.current_page_check();
}
getFilteredData(ActivatedRoute:any){
  this. BooksService.getWithFilters(<FilterParams>ActivatedRoute).subscribe(res =>{
    this.Books = res.data
    this.TotalCount = res.count;
    this.isTotlaCountsLess20 =  res.count>20;
    this.TotalPages = Math.ceil(res.count / 20);
  })
}
}
