import { Routes } from '@angular/router';
import { LoginComponent } from './auth/components/login/login.component';
import { CatelogComponent } from './books/catelog/catelog.component';
import { SavebookComponent } from './books/savebook/savebook.component';
import { RegisterComponent } from './auth/components/register/register.component';
import { authGuard } from './auth/guards/auth.guard';
import { checkAdminGuard } from './auth/guards/check-admin.guard';

export const routes: Routes = [
    {path:'login', component:LoginComponent},
    {path: 'books', component:CatelogComponent, canActivate:[authGuard]},
    {path: 'books/savebook', component:SavebookComponent, canActivate:[authGuard, checkAdminGuard]},
    {path: '', component:CatelogComponent},
    {path: 'register', component:RegisterComponent}
];
