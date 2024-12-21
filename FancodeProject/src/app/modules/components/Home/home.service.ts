import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface User {
  id: number;
  name: string;
  // ... other user properties
  address: {
    geo: {
      lat: number;
      lng: number;
    };
  };
}

interface Todo {
  userId: number;
  id: number;
  title: string;
  completed: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  private baseUrl = 'https://jsonplaceholder.typicode.com/';

  constructor(private http: HttpClient) { }

  // getUsers(): Observable<User[]> { 
  //   return this.http.get<User[]>(this.baseUrl + 'users');
  // }

  // getTodos(userId: number): Observable<Todo[]> { 
  //   return this.http.get<Todo[]>(`${this.baseUrl}/${userId}/todos`); 
  // }
}