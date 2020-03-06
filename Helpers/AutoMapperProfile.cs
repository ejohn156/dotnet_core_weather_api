using System;
using AutoMapper;
using dotnet_core_weather_api.Data.Entities;
using dotnet_core_weather_api.Models;

namespace dotnet_core_weather_api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUser, User>();
            CreateMap<CreateFavorite, Favorite>();
            CreateMap<Favorite, GetFavorite > ();
            CreateMap<Favorite, UserFavoriteReference>();
            CreateMap<User, GetUser>();
            CreateMap<Favorite, RequestGetUsersFavorites>();
        }

    }
}
