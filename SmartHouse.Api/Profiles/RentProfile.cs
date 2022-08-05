using AutoMapper;
using SmartHouse.Api.Dtos.Rents;
using SmartHouse.Core.Models;

namespace SmartHouse.Api.Profiles
{
    public class RentProfile : Profile
    {
        public RentProfile()
        {
            CreateMap<Rent, RentDto>().ReverseMap();
            CreateMap<Rent, CreateRentDto>().ReverseMap();
            CreateMap<Rent, UpdateRentDto>().ReverseMap();
        }
    }
}
