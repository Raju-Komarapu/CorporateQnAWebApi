using Microsoft.Data.SqlClient;
using System.Data;

namespace testingIdentityFramework
{
    public class DbContext
    {
        private readonly IConfiguration _configuration;

        private readonly string _connectionString;

        private readonly IDbConnection _connection;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("testingIdentityFrameworkContextConnection");
            _connection = new SqlConnection(_connectionString);
        }

        public IDbConnection GetConnection()
        {
            return _connection;
        }
    }
}
