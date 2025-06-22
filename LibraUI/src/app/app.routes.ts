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
import { UpdatebooksComponent } from './members/component/admindashboard/update/updatebooks/updatebooks.component';
import { RentalhistoryComponent } from './members/component/admindashboard/rentalhistoryall/rentalhistory/rentalhistory.component';
import { ChartComponent } from './members/component/admindashboard/chartcard/chart/chart.component';

export const routes: Routes = [
    {path:'login', component:LoginComponent},
    {path: 'books', component:CatelogComponent, canActivate:[authGuard]},
    // {path: 'books/savebook', component:SavebookComponent, canActivate:[authGuard, checkAdminGuard]},
    {path: 'books/rent/:id', component: NewrentalComponent, canActivate:[authGuard]},
    {path: 'register', component:RegisterComponent},
    {path: '', component:HomeComponent},
    {path: 'admin', component:AdmindashboardComponent, canActivate:[authGuard, checkAdminGuard], 

        children:[
            {path: '', component: RentalhistoryComponent},
            {path: 'admin/EditBook', component:CatelogComponent},
            {path: 'addbook', component:SavebookComponent},
            {path : 'chart', component:ChartComponent},
        ]
        
    },
    {path: 'myaccount', component:MyaccountComponent, canActivate: [authGuard]}

];
