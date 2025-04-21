import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RentService {

  constructor(private httpClient :HttpClient ) {}

  RentBook(bookId: number)
  {
    
    this.httpClient.post("http://localhost:5076/api/rental", {BookId: +bookId});
  }

  getRentalHistory()
  {
    this.httpClient.get("http://localhost:5076/api/rental/history");
  }

  returnBook(rentalId : number)
  {
    this.httpClient.put(`http://localhost:5076/api/rental/${rentalId}/return`,{});
  }
}
