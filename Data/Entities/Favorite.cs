using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnet_core_weather_api.Data.Entities
{
  public class Favorite
  {
    public int ID {get; set;}
    public string City { get; set; }
        [ForeignKey("UserId")]
    public int UserID { get; set; }
    public User User { get; set; }

    }
}
