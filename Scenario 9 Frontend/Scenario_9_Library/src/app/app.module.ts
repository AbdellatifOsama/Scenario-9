import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { HomeComponent } from './components/home/home.component';
import { BooksComponent } from './components/books/books.component';
import { AboutComponent } from './components/about/about.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { SearchComponent } from './components/search/search.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BookDetailsComponent } from './components/book-details/bookDetails.component';
import { CheckOutComponent } from './components/check-out/check-out.component';
import { AllCheckoutsComponent } from './components/all-checkouts/all-checkouts.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BooksComponent,
    AboutComponent,
    ContactsComponent,
    SearchComponent,
    BookDetailsComponent,
    CheckOutComponent,
    AllCheckoutsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
