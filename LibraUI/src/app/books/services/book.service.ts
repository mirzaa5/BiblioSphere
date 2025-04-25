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

  addBook(book:Book, coverImage: File |null)
  {

    console.log("Add Book method called");
    let formData = new FormData();
    formData.append("title", book.title);
    formData.append("isbn", book.isbn);
    formData.append("author.name", book.author.name);
    formData.append("category", book.category.toString());

    //if user selecte cover image
    if(coverImage)
    {
      console.log("add book has coverImage paramenter")
      formData.append("coverImage", coverImage);
    }else{
      console.log("coverImage is not added");
    }

    console.log("Resulting form data:", formData)

    this.http.post<Book>("http://localhost:5076/api/books",formData)
              .subscribe( d =>{
                this.books.next([...this.books.getValue(), d]);
              })
  }

  getBookById(bookId : number) : Observable<Book>
  {
      var response = this.http.get<Book>("http://localhost:5076/api/books/"+bookId)
      console.log("Get request response", response);
      return response
  }

  }

