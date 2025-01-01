import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthorRequest } from '../models/author-request.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UpdateAuthorRequest } from '../models/update-author-request.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  constructor(private http:HttpClient) { }

  addAuthor(model:{name:string}):Observable<void>{
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Authors/AddAuthor`, model);
  }

  getAllAuthors():Observable<AuthorRequest[]>{
    return this.http.get<AuthorRequest[]>(`${environment.apiBaseUrl}/api/Authors`);
  }

  getAuthorById(id:string):Observable<AuthorRequest>{
    return this.http.get<AuthorRequest>(`${environment.apiBaseUrl}/api/Authors/${id}`);
  }

  updateAuthor(id: string, updateAuthorRequest:UpdateAuthorRequest):Observable<UpdateAuthorRequest>{
    return this.http.put<UpdateAuthorRequest>(`${environment.apiBaseUrl}/api/Authors/${id}`,updateAuthorRequest);
  }

  deleteAuthor(id:string):Observable<AuthorRequest>{
    return this.http.delete<AuthorRequest>(`${environment.apiBaseUrl}/api/Authors/${id}`);
  }

}
