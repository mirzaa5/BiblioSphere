import { CommonModule, DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { Rental } from '../../../../types/rentalrecord';
import { RentService } from '../../../../../rentals/services/rent.service';

@Component({
  selector: 'app-rentalhistory',
  imports: [DatePipe, CommonModule],
  providers: [RentService],
  templateUrl: './rentalhistory.component.html',
  styleUrl: './rentalhistory.component.css'
})
export class RentalhistoryComponent {

  rentalHistory : Rental[] = [];
  rentalCount : { [membername:string] : number } = {}

  count(rentalHistory : Rental[])
  {
    for (const rental of this.rentalHistory)
    {
      const memberName = rental.member.name;
      if (this.rentalCount[memberName])
      {
        this.rentalCount[memberName] += 1;
      }
      else
      {
        this.rentalCount[memberName] = 1;
      }
    }

  }


  constructor(private rentalService: RentService) {
    rentalService.getAllRentalHistory().subscribe((data) =>{
      this.rentalHistory = data;
    
    })
  }


  ngOnInit() {

    this.count(this.rentalHistory); 
    console.log("Rental Cout", this.rentalCount)
  }

}
function foreach(arg0: boolean, p0: boolean) {
  throw new Error('Function not implemented.');
}

