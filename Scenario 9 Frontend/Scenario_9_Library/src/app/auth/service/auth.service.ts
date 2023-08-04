import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { EnvironmentSetup } from 'src/app/Environment/environment-setup';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _HttpClient:HttpClient) { }
  Login(form:FormGroup):Observable<any>{
    return this._HttpClient.post(`${EnvironmentSetup.baseUrl}/api/Account/login`,form.value)
  }
  Register(form:FormGroup):Observable<any>{
    return this._HttpClient.post(`${EnvironmentSetup.baseUrl}/api/Account/Register`,form.value)
  }
}
