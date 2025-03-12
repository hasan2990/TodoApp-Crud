using TodoApp_Restructuring_Backend.Models;
using TodoApp_Restructuring_Backend.Repositories.Interfaces;
using TodoApp_Restructuring_Backend.Services.Interfaces;

namespace TodoApp_Restructuring_Backend.Services.Implementations
{
    public class GetByIdTodoService : IGetByIdTodoService
    {
        private readonly IGetByIdTodos _getByIdTodos;
        public GetByIdTodoService(IGetByIdTodos getByIdTodos)
        {
            _getByIdTodos = getByIdTodos;
        }
        public Response GetByIdTodos(int id)
        {
            Response response = new Response();

            Todo todo = _getByIdTodos.GetByIdTodosRepo(id);
            
            if (todo != null)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.Todo = todo;
            }
            else
            {
                response.StatusCode = 500;
                response.StatusMessage = "Data Not Found";

            }
            return response;
        }
    }
}
