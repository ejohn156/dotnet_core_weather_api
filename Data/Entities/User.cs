using System;
using System.Collections.Generic;

namespace dotnet_core_weather_api.Data.Entities
{
  public class User
  {
    public int ID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public ICollection<Favorite> Favorites {get; set;}
  }
}
