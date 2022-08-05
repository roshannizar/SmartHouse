using AutoMapper;
using SmartHouse.Api.Dtos.Garbages;
using SmartHouse.Core.Models;

namespace SmartHouse.Api.Profiles
{
    public class GarbageProfile : Profile
    {
        public GarbageProfile()
        {
            CreateMap<CreateGarbageDto, Garbage>().ReverseMap();
            CreateMap<GarbageDto, Garbage>().ReverseMap();
            CreateMap<UpdateGarbageDto, Garbage>().ReverseMap();
        }
    }
}
