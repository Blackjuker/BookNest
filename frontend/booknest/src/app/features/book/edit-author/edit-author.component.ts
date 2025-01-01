import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthorService } from '../services/author.service';
import { AuthorRequest } from '../models/author-request.model';
import { FormsModule } from '@angular/forms';
import { UpdateAuthorRequest } from '../models/update-author-request.model';

@Component({
  selector: 'app-edit-author',
  templateUrl: './edit-author.component.html',
  styleUrls: ['./edit-author.component.css']
})
export class EditAuthorComponent implements OnInit, OnDestroy{

  id :string | null = null;
  paramSubscription?  : Subscription;
  editSubscription?  : Subscription;
  deleteSubscription? : Subscription;
  author? : AuthorRequest;
  /**
   *
   */
  constructor(private route:ActivatedRoute, private authorService:AuthorService,private router:Router) {
   
    
  }
  ngOnDestroy(): void {
    this.paramSubscription?.unsubscribe();
    this.editSubscription?.unsubscribe();
  }
  ngOnInit(): void {
   this.paramSubscription =  this.route.paramMap.subscribe({
      next:(params)=>{
        this.id = params.get('id');

        if (this.id){
            //get the data from api for this author
            this.authorService.getAuthorById(this.id)
              .subscribe({
                next: (response) =>{
                  this.author = response;
                }
              })
        }
      }
    });
  }

  onFormSubmit():void{
    const updateAuthorRequest : UpdateAuthorRequest = {
      name : this.author?.name ?? ''
    };

    // pass the object to service
    if(this.id)
    {
      this.editSubscription = this.authorService.updateAuthor(this.id,updateAuthorRequest)
        .subscribe({
          next: (response) =>{
            this.router.navigateByUrl('/admin/authors');
          }
        }); 
    }
  }

  onDelete():void{
    if (this.id){
      this.deleteSubscription =  this.authorService.deleteAuthor(this.id).subscribe({
        next: (response) =>{
          this.router.navigateByUrl('/admin/authors');
        }
      });
    }
   
  }




}
