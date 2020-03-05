using System;
using System.Collections.Generic;

namespace dotnet_core_weather_api.Models
{
    public class GetUser
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public List<UserFavoriteReference> Favorites { get; set; }
    }
}
