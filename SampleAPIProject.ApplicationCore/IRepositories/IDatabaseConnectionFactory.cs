using System;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SampleAPIProject.ApplicationCore.IRepositories
{
    public interface IDatabaseConnectionFactory
    {
       Task<MySqlConnection> CreateConnectionAsync();

    }
}
