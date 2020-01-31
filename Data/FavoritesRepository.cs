using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnet_core_weather_api.Data.Entities;
using dotnet_core_weather_api.Data;
namespace dotnet_core_weather_api.Data
{
    public interface IFavoritesRepository
    {
        void createFavorite(Favorite newFavorite);
        void deleteFavorite(int ID);
        IEnumerable<Favorite> getAllfavorites();
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

        public IEnumerable<Favorite> getAllfavorites()
        {
            return _favorites.Favorites.OrderBy(p => p.User)
            .ToList();
        }

        public List<int> getUsersWhoFavoritedCity(string city)
        {
            var ListOfUsers = new List<int>();
            var result = _favorites.Favorites.Where(I => I.City == city).ToList();
            foreach (Favorite fav in result)
            {
                ListOfUsers.Add(fav.User);
            }
            return ListOfUsers;
        }
        public void createFavorite(Favorite newFavorite)
        {

            _favorites.Favorites.Add(newFavorite);
            _favorites.SaveChanges();
        }
        public void deleteFavorite(int ID)
        {
            Favorite favoriteToDelete = _favorites.Favorites.ToList().Where(I => I.ID == ID).First();

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