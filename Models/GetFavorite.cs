using System;
using dotnet_core_weather_api.Data.Entities;

namespace dotnet_core_weather_api.Models
{
    public class GetFavorite
    {
        
            public int ID { get; set; }
            public string City { get; set; }
            public FavoriteUserReference User { get; set; }
        
    }
    
}
