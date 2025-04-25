import { Component } from '@angular/core';
import { Book } from '../../../books/types/book';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { BookService } from '../../../books/services/book.service';
import { RentService } from '../../services/rent.service';
import { CategoryPipe } from '../../../books/common/category.pipe';

@Component({
  selector: 'app-newrental',
  imports: [CommonModule, CategoryPipe],
  templateUrl: './newrental.component.html',
  styleUrl: './newrental.component.css'
})
export class NewrentalComponent {
  bookId: number = 0;
  book : Book = {} as Book ;

  constructor(private route:ActivatedRoute, private bookService:BookService, private rentService:RentService )
  {

    //getting the book id from URL
    this.route.params.subscribe(params => {
      this.bookId = params['id'];
    })

    //getting the book through bookId
    this.bookService.getBookById(this.bookId).subscribe(b =>{
      this.book = b
      console.log("Book Service used  inrental response",this.book)
      console.log("Author id repsosne",this.book.id)
      console.log("book available repsosne",this.book.isAvailable)
    });


  }
  ngOnInit()
  {
    console.log("Is book avaibalbe ?", this.book.isAvailable);
    console.log("Book Id from URL ?", this.bookId);
    console.log(this.book.isAvailable);
  }

  onRentBook()
  {
    this.rentService.RentBook(this.bookId).subscribe(d =>{
      this.book.isAvailable = false;
    })
  }

}
