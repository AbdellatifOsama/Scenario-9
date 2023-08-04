import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CartService } from 'src/app/Environment/cart.service';
import { CheckoutService } from 'src/app/Environment/checkout.service';

@Component({
  selector: 'app-check-out',
  templateUrl: './check-out.component.html',
  styleUrls: ['./check-out.component.scss']
})
export class CheckOutComponent {

constructor(private CartService:CartService,private CheckoutService:CheckoutService) {
  
}
checkoutFromGroup : FormGroup = new FormGroup({
  ApplicationUserEmail: new FormControl(null,[Validators.required,Validators.email]),
  visaCardNumber: new FormControl(null,[Validators.required]),
  visaCVV:  new FormControl<number>(0,[Validators.required]),
  visaExpireDate:  new FormControl(null),
  totalPrice:  new FormControl(null)
});
user = JSON.parse(<string>localStorage.getItem("user"));
btn = document.getElementById("modal-btn");
failedbtn = document.getElementById("failed-modal-btn")
totalprice  = 0;
carts :any[]=[];
isCheckedout=false;
CalculateTotalPrice(carts:any[]){
  this.totalprice  = 0;
  for (let index = 0; index < carts.length; index++) {
    this.totalprice+=carts[index].bookEntity.price;
  }
  console.log(this.totalprice)
}
ngOnInit(): void {
  this.btn = document.getElementById("modal-btn")
  this.failedbtn = document.getElementById("failed-modal-btn")

  //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
  //Add 'implements OnInit' to the class.
  this.getFromDatabae();
}
close(bookId:any){
this.CartService.DeleteCart(this.user.email,bookId).subscribe(res=>{
 this.getFromDatabae();
})
}
getFromDatabae(){
  this.CartService.GetAllCartsForUser(this.user.email).subscribe(res=>{
    this.carts = res;
    this.CalculateTotalPrice(this.carts);
  })
}
AddVisaCardNo(No:string){
  this.checkoutFromGroup.controls["visaCardNumber"].setValue(Number(No))
}
AddVisaExpireDate(No:string){
  this.checkoutFromGroup.controls["visaExpireDate"].setValue(Number(No))
}
AddVisaCvv(No:string){
  this.checkoutFromGroup.controls["visaCVV"].setValue(Number(No))
}
CheckoutSubmit(FormGroup:FormGroup){
  this.checkoutFromGroup.controls["ApplicationUserEmail"].setValue(this.user.email)
  this.checkoutFromGroup.controls["totalPrice"].setValue(this.totalprice);
  if (FormGroup.valid) {
    this.CheckoutService.AddCheckout(FormGroup).subscribe(res =>{
      if (res.message == "success") {
        this.carts =[];
        this.btn?.click();
      }
      else{
        this.failedbtn?.click();
      }
    })
  }
  else{
    this.failedbtn?.click();
  }
 }
}
