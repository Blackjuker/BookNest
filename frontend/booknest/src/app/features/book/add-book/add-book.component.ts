import { Component, OnDestroy } from '@angular/core';
import { AddBookRequest } from '../models/add-book-request.model';
import { BookService } from '../services/book.service';
import { Subscription } from 'rxjs';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnDestroy {

  model: AddBookRequest;
  bookForm!: FormGroup;

  private addBookSubscribtion?: Subscription;

  

  constructor(private bookService: BookService){
    this.model = {
      bookId: '',
      title: 'Sample Title', // Replace with actual data
      genres: null, // Use a valid Genre array if required
      publicationYear: 2023, // Replace with a valid year
      coverImage: 'sample-cover-url.jpg', // Provide a valid cover image URL or value
      createdAt: new Date(),
      isVisible: true,
      author: {authorId:'' ,name: 'Sample Author'}, // Ensure it matches the API structure
      totalPages: 200,
      isbn: '123-4567890123'
    };
  }

  ngOnInit(): void{

  }
  

  OnFormSubmit(){
    this.addBookSubscribtion = this.bookService.addCategory(this.model)
    .subscribe({
      next:(response)=> {
        console.log('This was successful');
      },
      error:(err) => {
        console.error('validation erros:', err.error.errors);
      }
    });
    console.log(this.model);
  }

  ngOnDestroy(): void {
    this.addBookSubscribtion?.unsubscribe();
  }
}
