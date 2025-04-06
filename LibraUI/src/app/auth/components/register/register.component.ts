import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  imports: [FormsModule,CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {



  constructor(private http : HttpClient){}
  onSubmit(registerForm : any) {
    console.log(registerForm.value);
    this.http.post("http://localhost:5076/api/registration", registerForm.value)
      .subscribe(
      (response) => console.log(response)
      ,(error)=>{
      console.log("Error Happened",error.message);
    })

    
  }
}
