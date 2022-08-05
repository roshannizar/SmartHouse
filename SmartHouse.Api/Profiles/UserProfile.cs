using AutoMapper;
using SmartHouse.Api.Dtos.Users;
using SmartHouse.Core.Models;
using SmartHouse.Shared.Api.Dtos;

namespace SmartHouse.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();

            CreateMap<User, BaseUserDto>().ReverseMap();
        }
    }
}
