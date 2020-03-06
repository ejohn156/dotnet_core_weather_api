using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnet_core_weather_api.Data.Entities;
using dotnet_core_weather_api.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnet_core_weather_api.Data
{
    public interface IUsersRepository
    {
        void createUser(User newUser);
        void deleteUser(int ID);
        IQueryable<User> getAllUsers();
        Task<User> getUser(int ID);
        bool SaveAll();
        bool SaveChanges();
        void UpdateUser(User updatedUser);
       IQueryable<Favorite> getUsersFavorites(int ID);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly WeatherAppContext _userContext;
        private readonly WeatherAppContext _favoriteContext;

        public UsersRepository(WeatherAppContext appContext)
        {
            _userContext = appContext;
            _favoriteContext = appContext;
        }

        public IQueryable<User> getAllUsers()
        {
            return _userContext.Users.Include(s => s.Favorites).OrderBy(p => p.Email);
        }

        public async Task<User> getUser(int ID)
        {

            var result = await _userContext.Users.Include(s => s.Favorites).Where(I => I.ID == ID).ToListAsync();
            return result.First();
        }
        public void createUser(User newUser)
        {

            _userContext.Users.Add(newUser);
            _userContext.SaveChanges();
        }
        public void deleteUser(int ID)
        {
            User userToDelete = _userContext.Users.ToList().Where(I => I.ID == ID).First();

            _userContext.Remove(userToDelete);
            _userContext.SaveChanges();
        }
        public void UpdateUser(User updatedUser)
        {
            User userToUpdate = _userContext.Users.ToList().Where(I => I.ID == updatedUser.ID).First();

            userToUpdate.Email = updatedUser.Email;
            userToUpdate.Password = updatedUser.Password;
            userToUpdate.Phone = updatedUser.Phone;
            _userContext.SaveChanges();
        }
        public IQueryable<Favorite> getUsersFavorites(int ID){
            var listOfFavorites = _favoriteContext.Favorites.Where(I => I.User.ID == ID);
            return listOfFavorites;
        }
        public bool SaveAll()
        {
            return _userContext.SaveChanges() > 0;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}