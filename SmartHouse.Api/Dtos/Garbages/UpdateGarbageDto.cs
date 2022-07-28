using SmartHouse.Shared.Core.Enums;
using System;

namespace SmartHouse.Api.Dtos.Garbages
{
    public class UpdateGarbageDto
    {
        public string Id { get; set; }
        public DateTime CollectingDate { get; set; }
        public GarbageTypes GarbageType { get; set; }
    }
}
