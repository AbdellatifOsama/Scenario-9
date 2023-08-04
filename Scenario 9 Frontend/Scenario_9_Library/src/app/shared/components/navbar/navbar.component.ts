import { Component } from '@angular/core';
import { Route, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  /**
   *
   */
  isLoggedIn = new BehaviorSubject<boolean>(false);
  user: any;
  constructor(private app: AppComponent, private _Router:Router) {
  }
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.

    if (localStorage.getItem("user") != null) {
      this.isLoggedIn.next(true);
      this.user = JSON.parse(<string>localStorage.getItem("user"));
    }
    else{
      this.isLoggedIn.next(false);
      this.user = null;
    }
   
  }
  logout(){
    this.user = null;
    this.isLoggedIn.next(false);
    localStorage.removeItem("user");
    this._Router.navigate(["/home"]);
  }
}
