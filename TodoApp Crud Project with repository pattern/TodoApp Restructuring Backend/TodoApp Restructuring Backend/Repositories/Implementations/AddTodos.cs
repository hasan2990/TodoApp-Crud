using Dapper;
using Microsoft.Data.SqlClient;
using TodoApp_Restructuring_Backend.Models;
using TodoApp_Restructuring_Backend.Models.DataSet;
using TodoApp_Restructuring_Backend.Repositories.Interfaces;

namespace TodoApp_Restructuring_Backend.Repositories.Implementations
{
    public class AddTodos : IAddTodos
    {
        private readonly IConfiguration _configuration;
        private readonly DbContext _dbContext;
        public AddTodos(IConfiguration configuration, DbContext dbContext)
        {
            _configuration = configuration;
            _dbContext  = dbContext;
        }

        public int AddTodosRepo(Todo todo)
        {
            int rowsAffected = 0;

            using (var connection = this._dbContext.Connection())
            {
                string query = @"INSERT INTO Demo (title, description, creation_date, due_date, iscompleted) 
                                 VALUES (@Title, @Description, GETDATE(), GETDATE(), @IsCompleted)";

                rowsAffected = connection.Execute(query, todo);
                
                
            }

            return rowsAffected;
        }
    }
}
