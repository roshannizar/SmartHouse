using AutoMapper;
using SmartHouse.Api.Dtos.WaterBills;
using SmartHouse.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHouse.Api.Profiles
{
    public class WaterBillProfile : Profile
    {
        public WaterBillProfile()
        {
            CreateMap<WaterBill, WaterBillDto>().ReverseMap();
            CreateMap<WaterBill, CreateWaterBillDto>().ReverseMap();
            CreateMap<WaterBill, UpdateWaterBillDto>().ReverseMap();
        }
    }
}
