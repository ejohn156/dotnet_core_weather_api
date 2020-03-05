using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnet_core_weather_api.Data.Entities;
using dotnet_core_weather_api.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dotnet_core_weather_api.Data
{
    public interface IFavoritesRepository
    {
        void createFavorite(Favorite newFavorite);
        void deleteFavorite(int ID);
        IQueryable<Favorite> getAllfavorites();
        List<int> getUsersWhoFavoritedCity(string city);
        bool SaveAll();
        bool SaveChanges();
    }

    public class favoritesRepository : IFavoritesRepository
    {
        private readonly WeatherAppContext _favorites;

        public favoritesRepository(WeatherAppContext appContext)
        {
            _favorites = appContext;
        }

        public IQueryable<Favorite> getAllfavorites()
        {
            var favorites = _favorites.Favorites.Include(f => f.User);
            return favorites;
        }

        public List<int> getUsersWhoFavoritedCity(string city)
        {
            var ListOfUsers = new List<int>();
            var result = _favorites.Favorites.Where(I => I.City == city).ToList();
            foreach (Favorite fav in result)
            {
                ListOfUsers.Add(fav.User.ID);
            }
            return ListOfUsers;
        }
        public void createFavorite(Favorite newFavorite)
        {
            var existingFavorites = _favorites.Favorites.Where(I => I.UserId == newFavorite.UserId).Where(I => I.City.Equals(newFavorite.City)).ToArray();
            if (existingFavorites.Length == 0)
            {
                _favorites.Favorites.Add(newFavorite);
                _favorites.SaveChanges();
            }

        }
        public void deleteFavorite(int ID)
        {
            Favorite favoriteToDelete = _favorites.Favorites.FirstOrDefault(I => I.ID == ID);

            _favorites.Remove(favoriteToDelete);
            _favorites.SaveChanges();
        }
        public bool SaveAll()
        {
            return _favorites.SaveChanges() > 0;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}