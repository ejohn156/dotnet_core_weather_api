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
using dotnet_core_weather_api.Models;
using AutoMapper;

namespace dotnet_core_weather_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _users;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository users, IMapper mapper){
            _users = users;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IEnumerable<User> getAllUsers (){
            return _users.getAllUsers();
        }
        [HttpPost("create")]
        public void CreateUser ([FromBody]CreateUser newUser){
            var user = _mapper.Map<User>(newUser);
          _users.createUser(user);
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
        public async Task<User> getUser (int Id){
            
            return await _users.getUser(Id);
        }
    }
}