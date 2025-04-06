import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpContext } from '@angular/common/http';
import { Token } from '../../types/token';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { AuthRequest } from '../../types/authrequest';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})


export class LoginComponent {
  LoginRequest : AuthRequest = {
    email : '',
    password : ''
  }

  errorReturned : string = '';

  @Output() onLogin = new EventEmitter();
  isEmpty : boolean = false;

  ngOnInit()
  {
    if(sessionStorage.getItem("token"))
    {
      // this.onLogin.emit();
      this.router.navigate(["/books"]);
    }
  }
  


  constructor(private http: HttpClient, private router: Router)
  {}

  onSubmit()
  {
    if(this.LoginRequest.email == '' || this.LoginRequest.password == '')
    {
      this.isEmpty =true;
    }
      this.http.post<Token>("http://localhost:5076/api/login", this.LoginRequest)
                .subscribe((response : Token) => {

                    sessionStorage.setItem("token", response.token)
                    sessionStorage.setItem("Expiration", response.expiration.toString())
                    sessionStorage.setItem("isAdmin", response.isAdmin.toString())
                    alert(response.token);
                    // this.onLogin.emit();
                    this.router.navigate(["/books"]);
                },
              (error)=>{
                  console.log(error);
                  this.errorReturned = error.error
                  
              })
  }

  
}
