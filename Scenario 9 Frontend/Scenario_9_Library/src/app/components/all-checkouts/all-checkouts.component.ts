import { Component } from '@angular/core';
import { CheckoutService } from 'src/app/Environment/checkout.service';
import { Checkout } from 'src/app/Interfaces/checkout';

@Component({
  selector: 'app-all-checkouts',
  templateUrl: './all-checkouts.component.html',
  styleUrls: ['./all-checkouts.component.scss']
})
export class AllCheckoutsComponent {
/**
 *
 */
constructor(private CheckoutService:CheckoutService) {
}
MyCheckouts :Checkout[]= [];
user = JSON.parse(<string> localStorage.getItem("user"));
ngOnInit(): void {
  //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
  //Add 'implements OnInit' to the class.
  this.CheckoutService.getCheckouts(this.user?.email).subscribe(res=>{
    this.MyCheckouts = res;
  })
  
}
}
