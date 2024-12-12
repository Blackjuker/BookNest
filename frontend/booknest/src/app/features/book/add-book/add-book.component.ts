import { Component } from '@angular/core';
import { AddBookRequest } from '../models/add-book-request.model';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent {

  model: AddBookRequest;

  constructor(){
    this.model = {
      name: '',
      isbn: ''
    };
  }

  OnFormSubmit(){

  }
}
