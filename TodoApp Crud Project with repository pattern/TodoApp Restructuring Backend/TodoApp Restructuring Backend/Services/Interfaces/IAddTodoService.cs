using Microsoft.Data.SqlClient;
using TodoApp_Restructuring_Backend.Models;

namespace TodoApp_Restructuring_Backend.Services.Interfaces
{
    public interface IAddTodoService
    {
        public Response AddTodos(Todo todo);
    }
}
