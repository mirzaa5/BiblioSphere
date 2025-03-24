import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../types/book';
import { Token } from '@angular/compiler';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  books = new BehaviorSubject<Book[]>([]);

  constructor(private http:HttpClient) { }

  getBooks() : Observable<Book[]>
  {
    this.http.get<Book[]>("http://localhost:5076/api/books/all")
            .subscribe((response : Book[])=>
              {
                  this.books.next(response);
              },
            (error)=>
              {
                 console.log(error);
              })

              return this.books
  }

  addBook(book:Book)
  {
    this.http.post<Book>("http://localhost:5076/api/books", book)
              .subscribe( d =>{
                this.books.next([...this.books.getValue(), d]);
              })
  }

  

  }

