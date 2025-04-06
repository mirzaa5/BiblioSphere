import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from './auth/components/login/login.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CatelogComponent } from "./books/catelog/catelog.component";
import { SavebookComponent } from "./books/savebook/savebook.component";
import { TopnavComponent } from "./common/topnav/topnav.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule, FormsModule, TopnavComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  
  isAuth : boolean =false;

  onAuth()
  {
    this.isAuth =true;
  }
}
