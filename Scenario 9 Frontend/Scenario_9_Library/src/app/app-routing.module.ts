import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { HomeComponent } from './components/home/home.component';
import { BooksComponent } from './components/books/books.component';
import { AboutComponent } from './components/about/about.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { SearchComponent } from './components/search/search.component';
import { BookDetailsComponent } from './components/book-details/bookDetails.component';
import { CheckOutComponent } from './components/check-out/check-out.component';
import { AllCheckoutsComponent } from './components/all-checkouts/all-checkouts.component';
import { AuthGuard } from './auth.guard';
CheckOutComponent
const routes: Routes = [
  {path:'',component:HomeComponent},
  {
    path: 'auth',
    component: AuthComponent,
    loadChildren: () => import('./auth/auth.module').then((m) => m.AuthModule),
  },
{path:'home',component:HomeComponent},
{path:'books',component:BooksComponent},
{path:'about',component:AboutComponent},
{path:'contacts',component:ContactsComponent,canActivate:[AuthGuard]},
{path:'search',component:SearchComponent},
{path:'checkout',component:CheckOutComponent,canActivate:[AuthGuard]},
{path:'bookdetails/:id',component:BookDetailsComponent},
{path:'checkouts',component:AllCheckoutsComponent,canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
