using TodoApp_Restructuring_Backend.Models;

namespace TodoApp_Restructuring_Backend.Repositories.Interfaces
{
    public interface IGetByIdTodos
    {
        public Todo GetByIdTodosRepo(int id);
    }
}
