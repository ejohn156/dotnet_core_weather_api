using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using dotnet_core_weather_api.Data;
using dotnet_core_weather_api.Data.Entities;

namespace dotnet_core_weather_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _users;

        public UsersController(IUsersRepository users){
            _users = users;
        }
        
        [HttpGet]
        public IEnumerable<User> getAllUsers (){
            return _users.getAllUsers();
        }
        [HttpPost("create")]
        public void CreateUser ([FromBody]User newUser){
          _users.createUser(newUser);
        }
        [HttpPost("delete/{User}")]
        public void DeleteUser (int ID){
            _users.deleteUser(ID);
        }
        [HttpPost("update")]
        public void UpdateUser ([FromBody]User user){
            _users.UpdateUser(user);
        }
        [HttpGet("{Id}")]
        public User getUser (int Id){
            
            return _users.getUser(Id);
        }
    }
}