import { Component, OnInit } from '@angular/core';
import { Todo } from '../../models/todo.model';
import { TodoService } from '../../services/todo.service';


@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.scss']

})
export class TodosComponent implements OnInit {

  todos: Todo[] = [];
  todosList: Todo[] = [];

  newTodo: Todo = {
    id: 0,
    title: '',
    description: '',
    creation_date: new Date(),
    due_date: new Date(),
    iscompleted: false,
    
  };


  constructor(private todoService: TodoService) { }

  ngOnInit(): void {
    this.getAllTodos();
  }

  getAllTodos() {
    this.todoService.getAllTodos().subscribe({
      next: (todos) => {
        console.log(todos);
        this.todos = todos;
        this.todosList = this.todos;
      }, error: (error) => {
        alert("Unable to get all");
      }
    });
  }

  addTodo() {
    // console.log(this.newTodo);
    this.todoService.addTodo(this.newTodo).subscribe({
      next: (todo) => {
        this.getAllTodos();
        this.todosList = this.todos;
        this.reset();

      }, error: (error) => {
        alert("Failed to Add");
      }
    });
  }
  deleteTodo(i: number) {
    this.todoService.deleteTodo(i).subscribe({
      next: (response) => {
        this.getAllTodos();
        this.todosList = this.todos;
      }, error: (error) => {
        alert("Failed to Delete");
      }
    });
  }

  updateTodo() {

    console.log("Update Todo");
    console.log(this.newTodo);
    
    this.todoService.updateTodo(this.newTodo).subscribe({
      next: (todo) => {
        this.getAllTodos();
        this.todosList = this.todos;
        this.reset();
      }, error: (error) => {
        alert("Failed to Update");
      }
    });
  }

  edittask(todo: Todo) {
    console.log("Edittask");
    console.log(todo);
    
    this.newTodo.id = todo.id;
    this.newTodo.title = todo.title;
    this.newTodo.description = todo.description;
    this.newTodo.due_date = todo.due_date;
    this.newTodo.iscompleted = todo.iscompleted;

  }

  onChange(todo: Todo) {
    console.log("Toggle todo:", todo);
    todo.iscompleted = !todo.iscompleted;
    console.log("Updated todo:", todo);
    this.todoService.updateTodo(todo).subscribe({
        next: () => {
            console.log("Todo updated successfully");
            this.getAllTodos();
        this.todosList = this.todos;

        },
        error: (error) => {
            console.error("Failed to update todo:", error);
            alert("Failed to update todo");
        }
    });
}
  completeStatus : boolean = true;

  showCompleted(){
    console.log("Completed");
    if(this.completeStatus){
      this.completeStatus = !this.completeStatus;
      this.todos = this.todos.filter(todo => todo.iscompleted);
    }
    else{
      this.completeStatus =!this.completeStatus;
      this.todos = this.todosList;
    }
    
  }
  reset(){
    
      this.newTodo.id= 0
      this.newTodo.title= ''
      this.newTodo.description= ''
      this.newTodo.creation_date= new Date()
      this.newTodo.due_date =new Date()
      this.newTodo.iscompleted= false
      
   
  }



}

