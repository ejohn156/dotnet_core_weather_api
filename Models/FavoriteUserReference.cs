using System;
namespace dotnet_core_weather_api.Models
{
    public class FavoriteUserReference
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
