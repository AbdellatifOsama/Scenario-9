import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EnvironmentSetup } from './environment-setup';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  constructor(private _httpClient:HttpClient) { }
  AddCheckout(formGroup:any):Observable<any>{
    return this._httpClient.post(`${EnvironmentSetup.baseUrl}/api/Checkout/Add`,formGroup.value)
  }
  getCheckouts(email:string):Observable<any>{
    return this._httpClient.get(`${EnvironmentSetup.baseUrl}/api/Checkout?email=${email}`)
  }
}
