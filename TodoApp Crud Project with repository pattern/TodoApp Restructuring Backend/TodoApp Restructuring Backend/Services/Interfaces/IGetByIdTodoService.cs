using TodoApp_Restructuring_Backend.Models;

namespace TodoApp_Restructuring_Backend.Services.Interfaces
{
    public interface IGetByIdTodoService
    {
        public Response GetByIdTodos(int id);
    }
}
