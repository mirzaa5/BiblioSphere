import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CatelogComponent } from '../catelog/catelog.component';
import {Book} from '../types/book'
import { BookService } from '../services/book.service';
import { TopnavComponent } from "../../common/topnav/topnav.component";

@Component({
  selector: 'app-savebook',
  imports: [FormsModule, CommonModule, ReactiveFormsModule],
  templateUrl: './savebook.component.html',
  styleUrl: './savebook.component.css'
})
export class SavebookComponent {

  coverImage: File | null = null;

  constructor(private bookService: BookService) { }

  bookgroup: FormGroup = new FormGroup({
    /*
        title : new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(1000)]),
        isbn : new FormControl('',Validators.required),
        author : new FormControl('', [Validators.required, Validators.pattern("^[a-zA-Z0-9]+$")] ),
        category : new FormControl('', Validators.required)*/
    title: new FormControl('', [Validators.required
      , Validators.maxLength(100)
      , Validators.minLength(2)]),
    isbn: new FormControl('', Validators.required),
    //Patten ^[a-zA-z0-9 ]+$ means that we are allowed only a-zA-Z0-9 and space with in the string
    //^ = Represents the start of the string
    //[] = Group where all allowes char or char range can be provided
    //a-z = Any lower case alphabetical character meaning from lowercase a-z 
    //+ = One more matching caracters
    //$ = Represents the end of the string
    author: new FormControl('', [Validators.required, Validators.pattern("^[a-zA-Z0-9 ]+$")]),
    category: new FormControl('', Validators.required)
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
     
    this.bookService.addBook(book, this.coverImage);
    }




 onFileChange(event : Event)
{

      //set event.target as an HtmlInputElement

      const input = event.target as HTMLInputElement
      console.log("checking file input")
      //checking if inlut emelent has a file
      if(input.files && input.files.length > 0)
      {
        console.log("asisinig file to coverImage")
        this.coverImage = input.files[0];
      }
  
}

  }












    // id : number,
    //   title : string,
    //   isbn : string,
    //   author : Author,
    //   category : number,
    //   isavailable : boolean,
    //   // coverImageUrl? : string


