import { Component } from '@angular/core';
import { AuthComponent } from '../../auth.component';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from '../../service/auth.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  /**
   *
   */
  isformValid = true;
  constructor(private _auhtcomponent: AuthComponent, private Router:Router,private _authService:AuthService) {
    _auhtcomponent.ActiveComponent = 'login'
  }
  loginFormGroup: FormGroup = new FormGroup({
    email: new FormControl<string>("", [Validators.required, Validators.email]),
    password: new FormControl(null, [Validators.required]),
  })
  login(FormGroup: FormGroup) {
    if (FormGroup.valid) {
      this._authService.Login(FormGroup).subscribe(res =>{
        if (res.message == "success") {
          this.AddToLocalStorage(res.data);
          window.location.pathname = "/books"
        }
      })
    }
  }
  AddToLocalStorage(jsondata:any){
    localStorage.setItem("user",JSON.stringify(jsondata))
  }
}
