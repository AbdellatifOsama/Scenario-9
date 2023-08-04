import { Component } from '@angular/core';
import { AuthComponent } from '../../auth.component';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  constructor(private _auhtcomponent:AuthComponent,private authService:AuthService,private _router:Router) {
    _auhtcomponent.ActiveComponent = 'register'
  }
  isRegisteredSuccess = false;
  RegisterFormGroup = new FormGroup({
    firstName: new FormControl<string>("",[Validators.required,Validators.maxLength(15),Validators.minLength(2)]),
    lastName: new FormControl<string>("",[Validators.required,Validators.maxLength(15),Validators.minLength(2)]),
    email: new FormControl<string>("",[Validators.required,Validators.email]),
    password: new FormControl<string>("",[Validators.required]),
    confirmPassword: new FormControl<string>("",[Validators.required]),
    gender: new FormControl<string>("",[Validators.required]),
    address: new FormControl<string>("",[Validators.required]),
    phoneNumber: new FormControl<string>("",[Validators.required]),
    isTermsAgreed: new FormControl<boolean>(false,[Validators.required]),
})
LoginFormGroup = new FormGroup({
  email: new FormControl<string>("",[Validators.required,Validators.email]),
  password: new FormControl<string>("",[Validators.required]),
})
PasswordChecker(password:string,RematchPassword:string){
  return password == RematchPassword;
}
AddToLocalStorage(jsondata:any){
  localStorage.setItem("user",JSON.stringify(jsondata))
}
FormSubmit(FormGroup:FormGroup){
  let email = FormGroup.controls['email'].value
  let password = FormGroup.controls['password'].value
  let Confirm = FormGroup.controls['confirmPassword'].value

  if (FormGroup.valid && this.PasswordChecker(password,Confirm)) {
    this.authService.Register(FormGroup).subscribe(res => {
      this.LoginFormGroup.controls['email'].setValue(email);
      this.LoginFormGroup.controls['password'].setValue(password);
      this.authService.Login(this.LoginFormGroup).subscribe(res => {
        this.AddToLocalStorage(res.data);
        window.location.pathname = "/books"
      })
    })
  }
  else{
    this.isRegisteredSuccess = true
  }
}
}
