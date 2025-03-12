using TodoApp_Restructuring_Backend.Models;

namespace TodoApp_Restructuring_Backend.Services.Interfaces
{
    public interface IDeleteTodoService
    {
        public Response DeleteTodos(int id);
    }
}
