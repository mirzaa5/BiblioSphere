import { CommonModule, NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RentService } from '../../../rentals/services/rent.service';
import { Rental } from '../../types/rentalrecord';
import { switchMap } from 'rxjs';

@Component({
  selector: 'app-myaccount',
  imports: [CommonModule],
  templateUrl: './myaccount.component.html',
  styleUrl: './myaccount.component.css'
})
export class MyaccountComponent {

  rentalHistory: Rental[] = [];

    constructor(private rentService: RentService) {


      this.rentService.getRentalHistory().subscribe((data)=>{
        this.rentalHistory = data
      });

    }

    
    onReturnBook(rentalId : number)
    {
      //1 Call API to return the book
      this.rentService.returnBook(rentalId)
      .pipe(
        //2 When retunr is done, call API to fetch new rental history
        switchMap(()=> this.rentService.getRentalHistory())
      )
      .subscribe((data)=>{
        //3 Get the rental history and update your varaible/UI
        this.rentalHistory = data;

      })
    }
}
