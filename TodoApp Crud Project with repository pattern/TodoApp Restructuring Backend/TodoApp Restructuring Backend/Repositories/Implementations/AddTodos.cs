using Dapper;
using TodoApp_Restructuring_Backend.Models;
using TodoApp_Restructuring_Backend.Models.DataSet;
using TodoApp_Restructuring_Backend.Repositories.Interfaces;

namespace TodoApp_Restructuring_Backend.Repositories.Implementations
{
    public class AddTodos : IAddTodos
    {
        private readonly DbContext _dbContext;
        public AddTodos(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddTodosRepo(Todo todo)
        {
            int rowsAffected = 0;

            using (var connection = this._dbContext.Connection())
            {
                //string query = @"INSERT INTO Demo (title, description, creation_date, due_date, iscompleted) 
                //                 VALUES (@Title, @Description, GETDATE(), GETDATE(), @IsCompleted)";

                //rowsAffected = connection.Execute(query, todo);
                try
                {
                    string query = @"INSERT INTO Demo (Id, Title, Description, Creation_Date, Due_Date, IsCompleted) 
                             VALUES (@id, @title, @description, GETDATE(), GETDATE(), @iscompleted)";
                    rowsAffected = connection.Execute(query, todo);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Error: {ex.Message}");
                    rowsAffected = -1;
                }
            }

            return rowsAffected;


        }
    }
}