import { Routes } from '@angular/router';
import { LoginComponent } from './auth/components/login/login.component';
import { CatelogComponent } from './books/catelog/catelog.component';
import { SavebookComponent } from './books/savebook/savebook.component';
import { RegisterComponent } from './auth/components/register/register.component';
import { authGuard } from './auth/guards/auth.guard';
import { checkAdminGuard } from './auth/guards/check-admin.guard';
import { HomeComponent } from './common/home/home.component';
import { NewrentalComponent } from './rentals/components/newrental/newrental.component';
import { AdmindashboardComponent } from './members/component/admindashboard/admindashboard.component';
import { MyaccountComponent } from './members/component/myaccount/myaccount.component';

export const routes: Routes = [
    {path:'login', component:LoginComponent},
    {path: 'books', component:CatelogComponent, canActivate:[authGuard]},
    {path: 'books/savebook', component:SavebookComponent, canActivate:[authGuard, checkAdminGuard]},
    {path: 'books.borrow/:id', component: NewrentalComponent, canActivate:[authGuard]},
    {path: 'register', component:RegisterComponent},
    {path: '', component:HomeComponent},
    {path: 'admin', component:AdmindashboardComponent},
    {path: 'myaccount', component:MyaccountComponent}
];
