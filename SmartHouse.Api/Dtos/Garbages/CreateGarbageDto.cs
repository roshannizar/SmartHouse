using SmartHouse.Shared.Core.Enums;
using System;

namespace SmartHouse.Api.Dtos.Garbages
{
    public class CreateGarbageDto
    {
        public DateTime CollectingDate { get; set; }
        public GarbageTypes GarbageType { get; set; }
        public string Weight { get; set; }
    }
}
