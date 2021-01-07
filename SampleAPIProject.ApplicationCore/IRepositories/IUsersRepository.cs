using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleAPIProject.ApplicationCore.Entities;

namespace SampleAPIProject.ApplicationCore.IRepositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> getAllUsers();

        Task<int> InsertUser(string userName);
    }
}
