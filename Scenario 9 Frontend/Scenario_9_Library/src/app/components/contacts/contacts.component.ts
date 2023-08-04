import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ContactsService } from 'src/app/Environment/contacts.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.scss']
})
export class ContactsComponent {

  constructor(private _ContactService:ContactsService) {
    
  }
  isubmittedSuccessfully =false;
    ContactsForm:FormGroup = new FormGroup({
      name : new FormControl(null,[Validators.required]),
      email : new FormControl(null,[Validators.email,Validators.required]),
      message : new FormControl(null,[Validators.required]),
    });
    submit(ContactsForm:FormGroup){
      if (ContactsForm.valid) {
        this._ContactService.SubmitMessage(ContactsForm).subscribe(res => {
          if (res.message == "success") {
            this.isubmittedSuccessfully = true;
          }
          else{
            this.isubmittedSuccessfully = false;
          }
        })
        
      }
      else{
        this.isubmittedSuccessfully = false;
      }
    }
}
