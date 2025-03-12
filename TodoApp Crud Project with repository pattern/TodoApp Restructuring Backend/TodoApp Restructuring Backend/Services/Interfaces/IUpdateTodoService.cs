using TodoApp_Restructuring_Backend.Models;

namespace TodoApp_Restructuring_Backend.Services.Interfaces
{
    public interface IUpdateTodoService
    {
        public Response UpdateTodos(Todo todo);
    }
}
