using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnet_core_weather_api.Data.Entities;
using dotnet_core_weather_api.Data;
namespace dotnet_core_weather_api.Data
{
    public interface IUsersRepository
    {
        void createUser(User newUser);
        void deleteUser(int ID);
        IEnumerable<User> getAllUsers();
        User getUser(int ID);
        bool SaveAll();
        bool SaveChanges();
        void UpdateUser(User updatedUser);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly WeatherAppContext _userContext;

        public UsersRepository(WeatherAppContext appContext)
        {
            _userContext = appContext;
        }

        public IEnumerable<User> getAllUsers()
        {
            return _userContext.Users.OrderBy(p => p.Email)
            .ToList();
        }

        public User getUser(int ID)
        {

            var result = _userContext.Users.Where(I => I.ID == ID);
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
            userToUpdate.Password = userToUpdate.Password;
            userToUpdate.Phone = userToUpdate.Phone;
            _userContext.SaveChanges();
        }
        public IEnumerable<Favorite> getUsersFavorites(int ID){
            User user = _userContext.Users.ToList().Where(I => I.ID == ID).First();
            return user.Favorites;
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