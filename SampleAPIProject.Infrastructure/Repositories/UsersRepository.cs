using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using SampleAPIProject.ApplicationCore.Entities;
using SampleAPIProject.ApplicationCore.IRepositories;

namespace SampleAPIProject.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        readonly IDatabaseConnectionFactory _dbCon;
        public UsersRepository(IDatabaseConnectionFactory dbCon)
        {
            this._dbCon = dbCon;
        }

        public async Task<IEnumerable<User>> getAllUsers()
        {
            var query = "SELECT * FROM Students";
            using (var con = await _dbCon.CreateConnectionAsync())
            {
                var result = con.QueryAsync<User>(query).Result.AsList();

                return result;
            }
        }

        public async Task<int> InsertUser(string userName)
        {
            var sp_name = "usp_insert_student";

            using (var con = await _dbCon.CreateConnectionAsync())
            {
                var param = new
                {
                    studentName = userName

                };

                var result = con.Execute(sp_name, param, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}

