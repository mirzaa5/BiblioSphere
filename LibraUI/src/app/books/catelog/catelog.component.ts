import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Book } from '../types/book';
import { HttpClient } from '@angular/common/http';
import { BookService } from '../services/book.service';

@Component({
  selector: 'app-catelog',
  imports: [FormsModule, CommonModule],
  templateUrl: './catelog.component.html',
  styleUrl: './catelog.component.css'
})
export class CatelogComponent {

  books : Book[] = [];

  constructor(private bookService  : BookService) { }


ngOnInit()
{
   this.bookService.getBooks()
            .subscribe( (b : Book[]) =>{
                this.books = b
            })
}


}













//   ngOnInit()
  
//   {
//     alert("requesting")
//     const jwtToken = sessionStorage.getItem("token");
//     this.http.get<Book[]>("http://localhost:5076/api/books/all")
//             .subscribe((response : Book[])=>
//               {
//                   this.books = response;
//               },
//             (error)=>
//               {
//                  console.log(error);
//               })
//   }
// }







//   
