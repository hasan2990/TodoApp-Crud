import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Todo } from '../models/todo.model'; // Ensure this import refers to the correct Todo type

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  // baseApiUrl: string = "https://localhost:7270"; 
  baseApiUrl: string = "https://localhost:7235"; 

  constructor(private http: HttpClient) { }

  getAllTodos(): Observable<Todo[]> {
    return this.http.get<any>(this.baseApiUrl + '/api/Todo/GetAllTodos').pipe(
      map(response => response.listtodo)
    );
  }


  addTodo(newTodo: Todo): Observable<Todo> {
   
    return this.http.post<Todo>(this.baseApiUrl + '/api/Todo/AddTodo', newTodo);
  }

  deleteTodo(id:number): Observable<Todo>{
    return this.http.delete<Todo>(this.baseApiUrl + '/api/Todo/DeleteTodo/' + id);
  }

  updateTodo(newTodo:Todo): Observable<Todo>{
    return this.http.put<Todo>(this.baseApiUrl + '/api/Todo/UpdateTodo', newTodo);
  }
}
