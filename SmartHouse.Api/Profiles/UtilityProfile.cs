using AutoMapper;
using SmartHouse.Api.Dtos.Utilities;
using SmartHouse.Core.Models;

namespace SmartHouse.Api.Profiles
{
    public class UtilityProfile : Profile
    {
        public UtilityProfile()
        {
            CreateMap<CreateUtilityDto, Utility>().ReverseMap();
            CreateMap<UpdateUtilityDto, Utility>().ReverseMap();
            CreateMap<UtilityDto, Utility>().ReverseMap();
        }
    }
}
