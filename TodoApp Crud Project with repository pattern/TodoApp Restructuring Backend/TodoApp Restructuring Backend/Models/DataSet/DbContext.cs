using Microsoft.Data.SqlClient;
using System.Data;

namespace TodoApp_Restructuring_Backend.Models.DataSet
{
    public class DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _databaseName;
        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _databaseName = _configuration.GetConnectionString("CrudConnection");
        }
        public IDbConnection Connection()=> new SqlConnection (this._databaseName);

    }
}
