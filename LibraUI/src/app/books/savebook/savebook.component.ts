import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CatelogComponent } from '../catelog/catelog.component';
import {Book} from '../types/book'
import { BookService } from '../services/book.service';

@Component({
  selector: 'app-savebook',
  imports: [FormsModule, CommonModule, ReactiveFormsModule],
  templateUrl: './savebook.component.html',
  styleUrl: './savebook.component.css'
})
export class SavebookComponent {

  constructor(private bookService : BookService){}

  bookgroup: FormGroup = new FormGroup({

    title : new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]),
    isbn : new FormControl('',Validators.required),
    author : new FormControl('', [Validators.required, Validators.pattern("^[a-zA-Z0-9]+$")] ),
    category : new FormControl('', Validators.required)
  })
  
  
  

  get title() {
    return this.bookgroup.get('title') as FormControl
  }

  get isbn() {
    return this.bookgroup.get('isbn') as FormControl
  }

  get author() {
    return this.bookgroup.get('author') as FormControl
  }

  get category() {
    return this.bookgroup.get('category') as FormControl
  }

  onSaveBook() {
    alert('Saving Book');
  
    this.bookgroup.markAllAsTouched();
    if(this.bookgroup.invalid)
    {
      alert("Form is invalid / Invalid Book Detials");
      return;
    }
    let book:Book  ={
      id : 0,
      title : this.title.value,
      isbn : this.isbn.value,
      author : {name: this.author.value , id : 0},
      category: +this.category.value, // this has to be turned from value ="1" string to number 1
      isavailable : true

    }
    console.log("authorname");
    console.log(book.author.name);
     
    this.bookService.addBook(book);
    }
  }

    // id : number,
    //   title : string,
    //   isbn : string,
    //   author : Author,
    //   category : number,
    //   isavailable : boolean,
    //   // coverImageUrl? : string


