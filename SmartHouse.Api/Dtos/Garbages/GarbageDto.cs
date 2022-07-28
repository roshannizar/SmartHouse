using SmartHouse.Shared.Core.Enums;
using System;

namespace SmartHouse.Api.Dtos.Garbages
{
    public class GarbageDto
    {
        public string Id { get; set; } 
        public DateTime CollectingDate { get; set; }
        public GarbageTypes GarbageType { get; set; }
        public String UserId { get; set; }
        public virtual UserGarbageDto User { get; set; }
    }

    public class UserGarbageDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
