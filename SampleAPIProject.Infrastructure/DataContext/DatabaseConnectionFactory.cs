using System;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SampleAPIProject.ApplicationCore.IRepositories;

namespace SampleAPIProject.Infrastructure.DataContext
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        public string ConnectionString { get; set; }

        public DatabaseConnectionFactory(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public async Task<MySqlConnection> CreateConnectionAsync()
        {
            var sqlConnection= new MySqlConnection(ConnectionString);
            await sqlConnection.OpenAsync();
            return sqlConnection;
        }


    }
}
