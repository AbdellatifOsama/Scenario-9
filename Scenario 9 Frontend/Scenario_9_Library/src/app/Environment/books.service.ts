import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FormGroup,FormControl  } from '@angular/forms';
import { FilterParams } from '../Interfaces/filter-params';
import { EnvironmentSetup } from './environment-setup';


@Injectable({
  providedIn: 'root'
})
export class BooksService {
  constructor(private _HttpClient:HttpClient) { }
  getAllBooks(pageindex:number):Observable<any>{
    return this._HttpClient.get(`${EnvironmentSetup.baseUrl}/api/Books?PageIndex=${pageindex}&PageSize=20`)
  }
  getAllBooksWithSort(pageindex:number,sort:string):Observable<any>{
    return this._HttpClient.get(`${EnvironmentSetup.baseUrl}/api/Books?PageIndex=${pageindex}&Sort=${sort}`)
  }
  getAllBooksWithSearch(pageindex:number,search:string):Observable<any>{
    return this._HttpClient.get(`${EnvironmentSetup.baseUrl}/api/Books?PageIndex=${pageindex}&Search=${search}`)
  }
  getAllCategories():Observable<any>{
    return this._HttpClient.get(`${EnvironmentSetup.baseUrl}/api/Books/Category`)
  }
  getWithFilters(queryParams:FilterParams):Observable<any>{
    return this._HttpClient.get(`${EnvironmentSetup.baseUrl}/api/Books/Filters?ISBN13=${queryParams.ISBN13}&MinPrice=${queryParams.MinPrice}&MaxPrice=${queryParams.MaxPrice}&Author=${queryParams.Author}&Title=${queryParams.Title}&Category=${queryParams.Category}&PageIndex=${queryParams.PageIndex}`)
  }
  getBook(id:number):Observable<any>{
    return this._HttpClient.get(`${EnvironmentSetup.baseUrl}/api/Books/${id}`)
  }

}
