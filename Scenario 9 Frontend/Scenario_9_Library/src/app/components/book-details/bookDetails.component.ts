import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BooksService } from 'src/app/Environment/books.service';
import { CartService } from 'src/app/Environment/cart.service';
import { IBook } from 'src/app/Interfaces/ibook';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.scss']
})
export class BookDetailsComponent {
  book :any;
isAddedSuccesfully = false;
constructor(private activeRoute:ActivatedRoute,private _Router:Router,private BooksService:BooksService,private CartService:CartService) {
 BooksService.getBook(activeRoute.snapshot.params['id']).subscribe(res =>{
  this.book = res;
  })
}
checkIfSignedin(){
  if (localStorage.getItem("user") != null) {
    return true;
  }
  else{
    return false;
  }
}
FormGroupBuilder(user:any){
  let cartFromGroup : FormGroup = new FormGroup({
    ApplicationUserEmail: new FormControl(user.email),
    bookEntityId: new FormControl(this.book.id),
    quantity: new FormControl(1),
    price:  new FormControl(this.book.price)
  });
  return cartFromGroup;
}
addCart(){
  if (this.checkIfSignedin()) {
    let user = JSON.parse(<string> localStorage.getItem("user"));
    var cartFromGroup=  this.FormGroupBuilder(user);
    this.CartService.AddCart(cartFromGroup).subscribe(res => {
      if (res.message == "success") {
        this.isAddedSuccesfully = true;
      }
      else{
        this.isAddedSuccesfully= false;
      }
    })
  }
  else{
    this._Router.navigate(["/auth/login"]);
  }
}

}
