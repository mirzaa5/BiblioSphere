import { Component } from '@angular/core';
import { HerosectionComponent } from "../herosection/herosection.component";
import { CatelogComponent } from "../../books/catelog/catelog.component";

@Component({
  selector: 'app-home',
  imports: [HerosectionComponent, CatelogComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
