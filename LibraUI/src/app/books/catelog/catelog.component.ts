import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Book } from '../types/book';
import { HttpClient } from '@angular/common/http';
import { BookService } from '../services/book.service';
import { SavebookComponent } from "../savebook/savebook.component";
import { RouterModule } from '@angular/router';
import { CategoryPipe } from '../common/category.pipe';
import { CategoryHighlightDirective } from '../../customDirective/category-highlight.directive';


@Component({
  selector: 'app-catelog',
  imports: [FormsModule, CommonModule, CategoryPipe, RouterModule, CategoryHighlightDirective ],
  templateUrl: './catelog.component.html',
  styleUrl: './catelog.component.css'
})
export class CatelogComponent {

  date = new Date;
  search : string =""
  books : Book[] = [];

  constructor(private bookService  : BookService) { }

// get( ) {

// }

ngOnInit()
{
   this.bookService.getBooks()
            .subscribe( (b : Book[]) =>{
                this.books = b
            })
}

//filter method
get  BookSearch() : Book[]
{
  return this.books.filter(b => b.title.toLowerCase().includes(this.search.toLowerCase()) 
  || b.author.name.toLowerCase().includes(this.search.toLowerCase()) );
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
