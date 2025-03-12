using TodoApp_Restructuring_Backend.Models;
using TodoApp_Restructuring_Backend.Repositories.Implementations;
using TodoApp_Restructuring_Backend.Repositories.Interfaces;
using TodoApp_Restructuring_Backend.Services.Interfaces;

namespace TodoApp_Restructuring_Backend.Services.Implementations
{
    public class UpdateTodoService: IUpdateTodoService
    {
        private readonly IUpdateTodos _uppdateTodo;
        public UpdateTodoService(IUpdateTodos uppdateTodo)
        {
            _uppdateTodo = uppdateTodo;
        }
        public Response UpdateTodos(Todo todo)
        {
            Response response = new Response();
            int i = _uppdateTodo.UpdateTodosRepo(todo);
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Todo Update";
                response.Todo = todo;

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Todo Update";

            }
            return response;

        }
    }
}
