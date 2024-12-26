import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) {}

  getUsers(): Observable<any[]> {
    return this.http.get<any[]>("http://localhost:5087/api/users");
  }

  addUser(user: any): Observable<any> {
    return this.http.post<any>("http://localhost:5087/api/users", user);
  }

  deleteUser(userId: number): Observable<any> {
    return this.http.delete<any>(`http://localhost:5087/api/users/${userId}`);
  }

}
