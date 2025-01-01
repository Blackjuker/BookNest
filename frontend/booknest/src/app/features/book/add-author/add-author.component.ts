import { Component } from '@angular/core';
import { AuthorRequest } from '../models/author-request.model';
import { AuthorService } from '../services/author.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-author',
  templateUrl: './add-author.component.html',
  styleUrls: ['./add-author.component.css']
})
export class AddAuthorComponent {

  model:{name:string};
  private addAuthorSubscription?:Subscription;

  /**
   *
   */
  constructor(private authorService:AuthorService, private router:Router) {
    this.model  = {
      name : ""
    };    
  }

  onFormSubmit(){
    this.addAuthorSubscription   = this.authorService.addAuthor(this.model)
                        .subscribe({
                          next:(response)=>{
                            console.log('this was successful');
                            this.router.navigateByUrl('/admin/authors');
                          },
                          error:(err) => {
                            console.error('validation errors: ', err.error.errors);
                          }
                        });
    console.log(this.model);
  }

  ngOnDestroy():void{
    this.addAuthorSubscription?.unsubscribe();
  }


}
