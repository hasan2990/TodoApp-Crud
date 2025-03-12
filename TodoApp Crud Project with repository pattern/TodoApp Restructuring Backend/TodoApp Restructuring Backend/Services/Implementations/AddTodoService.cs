using TodoApp_Restructuring_Backend.Models;
using TodoApp_Restructuring_Backend.Services.Interfaces;
using TodoApp_Restructuring_Backend.Repositories.Interfaces;




namespace TodoApp_Restructuring_Backend.Services.Implementations
{
    public class AddTodoService: IAddTodoService
    {
        private readonly IAddTodos _addTodo;
        public AddTodoService(IAddTodos addTodo)
        {
            _addTodo = addTodo;
        }
        public Response AddTodos(Todo todo)
        {
            Response response = new Response();
            int i = _addTodo.AddTodosRepo(todo);
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Todo Added";
                response.Todo = todo;

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Todo inserted";

            }
            return response;

        }

    }


}
