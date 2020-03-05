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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>()
                .HasOne(s => s.User)
                .WithMany(s => s.Favorites);
                
                

            modelBuilder.Entity<User>()
                .HasMany(s => s.Favorites)
                .WithOne(s => s.User);
        }
    }
    
}