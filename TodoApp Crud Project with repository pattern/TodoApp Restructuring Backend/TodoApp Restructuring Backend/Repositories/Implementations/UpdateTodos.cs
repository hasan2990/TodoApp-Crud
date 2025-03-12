using Dapper;
using Microsoft.Data.SqlClient;
using TodoApp_Restructuring_Backend.Models;
using TodoApp_Restructuring_Backend.Models.DataSet;
using TodoApp_Restructuring_Backend.Repositories.Interfaces;

namespace TodoApp_Restructuring_Backend.Repositories.Implementations
{
    public class UpdateTodos : IUpdateTodos
    {
        private readonly IConfiguration _configuration;
        private readonly DbContext _dbContext;

        public UpdateTodos(IConfiguration configuration, DbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public int UpdateTodosRepo(Todo todo)
        {
            int rowsAffected = 0;

            using (var connection = this._dbContext.Connection())
            {
                string query = "UPDATE Demo SET title = @Title, description = @Description,  due_date = GETDATE() WHERE id = @Id";

                rowsAffected = connection.Execute(query, todo);
               
            }

            return rowsAffected;
        }

    }
}
