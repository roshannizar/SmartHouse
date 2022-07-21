using AutoMapper;
using SmartHouse.Api.Dtos.Users;
using SmartHouse.Core.Models;

namespace SmartHouse.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
        }
    }
}
