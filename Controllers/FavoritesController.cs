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
using AutoMapper;
using dotnet_core_weather_api.Models;
using dotnet_core_weather_api.Helpers;

namespace dotnet_core_weather_api.Controllers
{
    [ApiController]
    [Route("api/favorite")]
    public class FavoritesController : ControllerBase
    {
        private readonly IUsersRepository _user;
        private readonly IFavoritesRepository _favorites;
        private readonly IMapper _mapper;

        public FavoritesController(IFavoritesRepository favorites, IMapper mapper, IUsersRepository user){
            _favorites = favorites;
            _mapper = mapper;
            _user = user;
        }
        [HttpGet]
        public IActionResult GetAllFavorites (){
            try
            {
                var favorites = _favorites.getAllfavorites();
                var model = _mapper.Map<IList<GetFavorite>>(favorites);
                return Ok(model);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }

        }
        [HttpPost("create")]
        public IActionResult CreateFavorite ([FromBody]CreateFavorite newFavorite){

            try
            {

                var favorite = _mapper.Map<Favorite>(newFavorite);
                _favorites.createFavorite(favorite);
                return Ok(favorite);

            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
            
        }
        [HttpPost("delete/{ID}")]
        public IActionResult DeleteFavorite (int ID){
            try
            {
                
                _favorites.deleteFavorite(ID);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
            
        }
        [HttpGet("{City}")]
        public IActionResult listOfUsersWhoFavorited (string city){
            
            try
            {
                List<int> userIds = _favorites.getUsersWhoFavoritedCity(city);
                return Ok(userIds);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}