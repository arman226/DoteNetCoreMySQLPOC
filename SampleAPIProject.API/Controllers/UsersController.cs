using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPIProject.ApplicationCore.IRepositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleAPIProject.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController :ControllerBase
    {
        private readonly IUsersRepository _userRepository;


        public UsersController(IUsersRepository userRepository)
        {
            this._userRepository = userRepository;

        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var result = await _userRepository.getAllUsers();
                return Ok(result);
            }
            catch (Exception error)
            {

                return Ok(error.Message);
            }

        }


        [HttpPost]
        [Route("Create User")]
        public async Task<IActionResult> CreateUser(string user)
        {
            try
            {
                var result = await _userRepository.InsertUser(user);
                return Ok(result);
            }
            catch (Exception error)
            {

                return Ok(error.Message);
            }

        }

    }
}
