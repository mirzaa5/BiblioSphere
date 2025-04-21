import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from './auth/components/login/login.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CatelogComponent } from "./books/catelog/catelog.component";
import { SavebookComponent } from "./books/savebook/savebook.component";
import { TopnavComponent } from "./common/topnav/topnav.component";
import { FooterComponent } from "./common/footer/footer.component";
import { HerosectionComponent } from "./common/herosection/herosection.component";
import { HomeComponent } from "./common/home/home.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule, FormsModule, TopnavComponent, FooterComponent, ],
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
