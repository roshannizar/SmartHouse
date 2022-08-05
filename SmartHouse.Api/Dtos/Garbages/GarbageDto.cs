using SmartHouse.Shared.Api.Dtos;
using SmartHouse.Shared.Core.Enums;
using System;

namespace SmartHouse.Api.Dtos.Garbages
{
    public class GarbageDto
    {
        public string Id { get; set; } 
        public DateTime CollectingDate { get; set; }
        public GarbageTypes GarbageType { get; set; }
        public string Weight { get; set; }
        public string UserId { get; set; }
        public virtual BaseUserDto User { get; set; }
    }
}
