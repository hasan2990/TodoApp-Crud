using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TodoApp_Restructuring_Backend.Models.DataSet;
using TodoApp_Restructuring_Backend.Repositories.Interfaces;

namespace TodoApp_Restructuring_Backend.Repositories.Implementations
{
    public class DeleteTodos : IDeleteTodos
    {
        private readonly IConfiguration _configuration;
        private readonly DbContext _dbContext;

        public DeleteTodos(IConfiguration configuration, DbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public int DeleteTodosRepo(int id)
        {
            int rowsAffected = 0;

            using (var connection = this._dbContext.Connection())
            {
                string query = "DELETE FROM Demo WHERE id = @Id";

                try
                {
                    rowsAffected = connection.Execute(query, new { Id = id });
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
            }

            return rowsAffected;
        }
    }
}
