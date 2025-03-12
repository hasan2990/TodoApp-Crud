using TodoApp_Restructuring_Backend.Repositories.Interfaces;
using TodoApp_Restructuring_Backend.Models;
using TodoApp_Restructuring_Backend.Services.Interfaces;
namespace TodoApp_Restructuring_Backend.Services.Implementations
{
    public class GetAllTodoService : IGetAllTodoService
    {
        private readonly IGetAllTodos _getAllTodos;
        public GetAllTodoService(IGetAllTodos getAllTodos)
        {
            _getAllTodos = getAllTodos;
        }
        public Response GetAllTodos()
        {
            Response response = new Response();

            List<Todo> TodoList = _getAllTodos.GetAllTodosRepo();
            if(TodoList.Count > 0) 
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.listtodo = TodoList;
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
