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
    [Route("api/favorite")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesRepository _favorites;

        public FavoritesController(IFavoritesRepository favorites){
            _favorites = favorites;
        }
        [HttpGet]
        public IEnumerable<Favorite> getAllFavorites (){
            return _favorites.getAllfavorites();
        }
        [HttpPost("create")]
        public void CreateFavorite ([FromBody]Favorite newFavorite){
          _favorites.createFavorite(newFavorite);
        }
        [HttpPost("delete/{Favorite}")]
        public void DeleteFavorite (int ID){
            _favorites.deleteFavorite(ID);
        }
        [HttpGet("{City}")]
        public List<int> listOfUsersWhoFavorited (string city){
            List<int> userIds = _favorites.getUsersWhoFavoritedCity(city);
            return userIds;
        }
    }
}