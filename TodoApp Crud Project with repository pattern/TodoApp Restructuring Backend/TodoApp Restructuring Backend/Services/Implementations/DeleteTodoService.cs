using TodoApp_Restructuring_Backend.Models;
using TodoApp_Restructuring_Backend.Repositories.Interfaces;
using TodoApp_Restructuring_Backend.Services.Interfaces;


namespace TodoApp_Restructuring_Backend.Services.Implementations
{
    public class DeleteTodoService : IDeleteTodoService
    {
        private readonly IDeleteTodos _deleteTodo;
        public DeleteTodoService(IDeleteTodos deleteTodo)
        {
            _deleteTodo = deleteTodo;
        }
        public Response DeleteTodos(int id)
        {
            Response response = new Response();
            int i = _deleteTodo.DeleteTodosRepo(id);
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Todo deleted";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Todo deleted";

            }
            return response;
        }
    }
}
