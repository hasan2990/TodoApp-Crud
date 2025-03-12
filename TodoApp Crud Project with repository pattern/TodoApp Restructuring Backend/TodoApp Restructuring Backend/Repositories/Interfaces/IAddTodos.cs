using Microsoft.Data.SqlClient;
using TodoApp_Restructuring_Backend.Models;

namespace TodoApp_Restructuring_Backend.Repositories.Interfaces
{
    public interface IAddTodos
    {
        public int AddTodosRepo(Todo todo);
    }
}
