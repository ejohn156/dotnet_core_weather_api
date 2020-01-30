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
        private readonly IfavoritesRepository _favorites;

        public FavoritesController(IfavoritesRepository favorites){
            _favorites = favorites;
        }
        [HttpGet]
        public IEnumerable<Favorite> getUsersFavorites (){
            return _favorites.getAllfavorites();
        }
        [HttpPost("/create/{Favorite}")]
        public void CreateFavorite ([FromBody]Favorite newFavorite){
          _favorites.createFavorite(newFavorite);
        }
        [HttpPost("/delete/{Favorite}")]
        public void DeleteFavorite ([FromBody]int ID){
            _favorites.deleteFavorite(ID);
        }
        [HttpGet("/{City}")]
        public List<int> listOfUsersWhoFavorited ([FromBody]string city){
            List<int> userIds = _favorites.getUsersWhoFavoritedCity(city);
            return userIds;
        }
    }
}