using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using TodoApp_Restructuring_Backend.Models;
using TodoApp_Restructuring_Backend.Models.DataSet;
using TodoApp_Restructuring_Backend.Repositories.Interfaces;

namespace TodoApp_Restructuring_Backend.Repositories.Implementations
{
    public class GetAllTodo: IGetAllTodos
    {

        private readonly IConfiguration _configuration;
        private readonly DbContext _dbContext;
        public GetAllTodo(IConfiguration configuration, DbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public List<Todo> GetAllTodosRepo()
        {
            
            List<Todo> lsttodos = new List<Todo>();

            using (var connection = this._dbContext.Connection())
            {
                string query = "SELECT * FROM Demo";
                try
                {
                    lsttodos = connection.Query<Todo>(query).ToList();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                return lsttodos;
            }
        }

    }
}
