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
using dotnet_core_weather_api.Helpers;

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
        public IActionResult getAllUsers (){
            try
            {
           
                var users = _users.getAllUsers();
                var model = _mapper.Map<IList<GetUser>>(users);
                return Ok(model);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
            
        }
        [HttpPost("create")]
        public IActionResult createUser([FromBody]CreateUser newUser){
            try
            {
                var user = _mapper.Map<User>(newUser);
                _users.createUser(user);
                return Ok(user);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
            
        }
        [HttpPost("delete/{ID}")]
        public IActionResult DeleteUser (int ID){
            try
            {
                _users.deleteUser(ID);
                return Ok("User with ID: " + ID + "has been deleted");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
            
        }
        [HttpPost("update")]
        public IActionResult UpdateUser ([FromBody]User user){
            try
            {
                _users.UpdateUser(user);
                return Ok(user);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
            
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> getUser (int Id){
            try
            {
                var user = await _users.getUser(Id);
                return Ok(user);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
            
        }
        [HttpGet("{Id}/favorites")]
        public IActionResult getUsersFavorites(int Id)
        {
            try
            {
                var user =  _users.getUsersFavorites(Id).ToList();
                var model = _mapper.Map<IList<RequestGetUsersFavorites>>(user);
                return Ok(model);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }

        }
    }
}
