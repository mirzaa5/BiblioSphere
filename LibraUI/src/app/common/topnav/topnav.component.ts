import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../auth/services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-topnav',
  imports: [RouterModule, CommonModule],
  templateUrl: './topnav.component.html',
  styleUrl: './topnav.component.css'
})
export class TopnavComponent {
  hideMenu = false;
  isLoggedIn : boolean = false;
  isAdmin = sessionStorage.getItem("isAdmin");
  
  constructor(private authService : AuthService)
  {
    
    this.isLoggedIn = sessionStorage.getItem("token") != null;
    console.log(this.isLoggedIn);
    this.authService.isLoggedIn.subscribe((isLoggedIn:boolean)=>{
        this.isLoggedIn = isLoggedIn;
        

    });
  }
  
  onLogout()
  {
    sessionStorage.removeItem("token");
  }

  ngOnInit()
  {
    console.log("Top nac component, is Admin : ", this.isAdmin);
    console.log("Hide menu is ", this.hideMenu)
  }
}
