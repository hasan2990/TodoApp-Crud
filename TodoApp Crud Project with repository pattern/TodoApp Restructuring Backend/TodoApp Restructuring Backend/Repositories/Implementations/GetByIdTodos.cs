using Azure;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using TodoApp_Restructuring_Backend.Models;
using TodoApp_Restructuring_Backend.Models.DataSet;
using TodoApp_Restructuring_Backend.Repositories.Interfaces;

namespace TodoApp_Restructuring_Backend.Repositories.Implementations
{
    public class GetByIdTodos : IGetByIdTodos
    {
        public readonly IConfiguration _configuration;
        public readonly DbContext _dbContext;

        public GetByIdTodos(IConfiguration configuration, DbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public Todo GetByIdTodosRepo(int id)
        {
            Todo todo = new Todo();

            using (var connection = this._dbContext.Connection())
            {
                string query = "SELECT * FROM Demo WHERE id = @Id";
              
                 todo = connection.QueryFirstOrDefault<Todo>(query, new { Id = id });


                return todo;

            }
        }

    }
}
