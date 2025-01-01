import { Component, OnInit } from '@angular/core';
import { AuthorService } from '../services/author.service';
import { AuthorRequest } from '../models/author-request.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.css']
})
export class AuthorListComponent implements OnInit {


  //authors?: AuthorRequest[];

  authors$?: Observable<AuthorRequest[]>;
  /**
   *
   */
  constructor(private authorService: AuthorService) {    
  }
  ngOnInit(): void {
    // this.authorService.getAllAuthors()
    // .subscribe({
    //   next: (response)=>{
    //     this.authors = response;
    //   }})
    this.authors$ = this.authorService.getAllAuthors();
    
  }


}   
