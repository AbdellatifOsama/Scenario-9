import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentSetup } from './environment-setup';
import { Observable } from 'rxjs';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  constructor(private _HttpClient:HttpClient) { }
  SubmitMessage(FormGroup:FormGroup):Observable<any>{
    return this._HttpClient.post(`${EnvironmentSetup.baseUrl}/api/Contacts`,FormGroup.value)
  }
}
