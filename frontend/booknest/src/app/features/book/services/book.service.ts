import { Injectable } from '@angular/core';
import { AddBookRequest } from '../models/add-book-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  // addCategory(model : AddBookRequest): Observable<void>{
  //   return this.http.post<void>('https://localhost:772/api/books',model);
  // }

  addCategory(model: AddBookRequest):Observable<void>{
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Books`, model);
  }
}
