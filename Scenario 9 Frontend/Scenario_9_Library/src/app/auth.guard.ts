import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private _router:Router) {
    
  }
  canActivate(){
    let user = localStorage.getItem("user");
    if (user!= null) {
      return true;
    }
    else{
      this._router.navigate(["/auth/login"]);
      return false;
    }
  }
  
}
