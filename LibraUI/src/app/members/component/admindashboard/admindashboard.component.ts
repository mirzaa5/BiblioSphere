import { Component } from '@angular/core';
import { RentService } from '../../../rentals/services/rent.service';
import { Rental } from '../../types/rentalrecord';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ChartComponent } from "./chartcard/chart/chart.component";

@Component({
  selector: 'app-admindashboard',
  imports: [CommonModule, RouterModule],
  templateUrl: './admindashboard.component.html',
  styleUrl: './admindashboard.component.css'
})
export class AdmindashboardComponent {

  RentalHistory : Rental[] = [];

  constructor(private rentalService: RentService) {
    // You can initialize any properties or call methods here if needed
    this.rentalService.getAllRentalHistory().subscribe((data) =>{
      this.RentalHistory = data;
    })
  }
}
