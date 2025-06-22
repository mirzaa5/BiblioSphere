import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Rental } from '../../members/types/rentalrecord';

@Injectable({
  providedIn: 'root'
})
export class RentService {

  constructor(private httpClient :HttpClient ) {}

  RentBook(bookId: number)
  {
    
   return this.httpClient.post("http://localhost:5076/api/rental", {BookId: +bookId});
  }

  getRentalHistory()
  {
    return this.httpClient.get<Rental[]>("http://localhost:5076/api/rental/history");
  }

  returnBook(rentalId : number)
  {
    return this.httpClient.put(`http://localhost:5076/api/rental/${rentalId}/return`,{});
  }

  getAllRentalHistory()
  {
    return this.httpClient.get<Rental[]>("http://localhost:5076/api/rental/all");
  }
}
