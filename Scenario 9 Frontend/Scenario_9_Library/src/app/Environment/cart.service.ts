import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EnvironmentSetup } from './environment-setup';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private _httpClient:HttpClient) { }
  AddCart(formGroup:any):Observable<any>{
    return this._httpClient.post(`${EnvironmentSetup.baseUrl}/api/Carts/Add`,formGroup.value)
  }
  GetAllCartsForUser(id:any):Observable<any>{
    return this._httpClient.get(`${EnvironmentSetup.baseUrl}/api/Carts/Get?email=${id}`)
  }
  DeleteCart(email:any,bookId:any):Observable<any>{
    return this._httpClient.delete(`${EnvironmentSetup.baseUrl}/api/Carts/Delete?email=${email}&bookId=${bookId}`)
  }

}
