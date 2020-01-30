using System;
using System.Collections.Generic;

namespace dotnet_core_weather_api.Data.Entities
{
  public class Favorite
  {
    public int ID {get; set;}
    public String City { get; set; }
    public int User { get; set; }

  }
}
