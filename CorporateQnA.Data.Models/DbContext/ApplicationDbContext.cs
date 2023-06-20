using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CorporateQnA.Infrastructure.DbContext
{
    public class ApplicationDbContext
    {
        private readonly IConfiguration _configuration;

        private readonly string _connectionString;

        private readonly IDbConnection _connection;

        public ApplicationDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._connectionString = this._configuration.GetConnectionString("TeamLDBConnection");
            this._connection = new SqlConnection(_connectionString);
        }

        public T Get<T>(Guid id) where T : class
        {
            return this._connection.Get<T>(id);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return this._connection.GetAll<T>();
        }

        public void Insert<T>(T entity) where T : class
        {
            this._connection.Insert(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this._connection.Update(entity);
        }

        public void Execute(string query, object parameters = null)
        {
            this._connection.Execute(query, parameters);
        }

        public T ExecuteScalar<T>(string query, object parameters = null)
        {
            return this._connection.ExecuteScalar<T>(query, parameters);
        }

        public T QuerySingleOrDefault<T>(string query, object parameters = null)
        {
            return this._connection.QuerySingleOrDefault<T>(query, parameters);
        }

        public IEnumerable<T> Query<T>(string query, object parameters = null)
        {
            return this._connection.Query<T>(query, parameters);
        }
    }
}
