import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MainServiceService {
  baseUrl =  "http://localhost:5087/";
  
    constructor(private http: HttpClient) {}
  
    getNotes(): Observable<any[]> {
      return this.http.get<any[]>( this.baseUrl + "api/users" );
    }

}
