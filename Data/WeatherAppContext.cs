using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnet_core_weather_api.Data.Entities;

namespace dotnet_core_weather_api.Data
{
    public class WeatherAppContext : DbContext
    {
        public WeatherAppContext(DbContextOptions<WeatherAppContext> options) : base(options)
        {
            
        }        
        public DbSet<Favorite> Favorites{get; set;}
        public DbSet<User> Users{get; set;}
        
    } 
}