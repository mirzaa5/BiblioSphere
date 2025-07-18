import { Component } from '@angular/core';
import {Chart} from 'chart.js';

@Component({
  selector: 'app-chart',
  imports: [], // Removed as it is not valid here
  templateUrl: './chart.component.html',
  styleUrl: './chart.component.css'
})
export class ChartComponent {
 public chart: any;

 borrowingChartData = {
    labels: ['2022-05-10', '2022-05-11', '2022-05-12', '2022-05-13',
             '2022-05-14', '2022-05-15', '2022-05-16', '2022-05-17'],
    datasets: [
      {
        label: "Sales",
        data: ['467', '576', '572', '79', '92', '574', '573', '576'],
        backgroundColor: 'blue'
      },
      {
        label: "Profit",
        data: ['542', '542', '536', '327', '17', '0.00', '538', '541'],
        backgroundColor: 'limegreen'
      }
    ]
 };

 ngOnInit() {
   this.chart = new Chart("MyChart", {
     type: 'bar', // this denotes the type of chart
     data: this.borrowingChartData,
     options: {
       aspectRatio: 2.5
     }
   });
 }
}
