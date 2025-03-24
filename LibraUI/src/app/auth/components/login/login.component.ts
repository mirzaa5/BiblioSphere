import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthRequest } from '../../types/AuthRequest';
import { HttpClient, HttpContext } from '@angular/common/http';
import { Token } from '../../types/token';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})


export class LoginComponent {
  LoginRequest : AuthRequest = {
    email : '',
    password : ''
  }

  @Output() onLogin = new EventEmitter();
  isEmpty : boolean = false;

  ngOnInit()
  {
    if(sessionStorage.getItem("token"))
    {
      this.onLogin.emit();
    }
  }
  


  constructor(private http: HttpClient)
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
                    alert(response.token);
                    this.onLogin.emit();
                },
              (error)=>{
                  console.log(error);
                  alert("Something went wrong");
              })
  }

  
}
