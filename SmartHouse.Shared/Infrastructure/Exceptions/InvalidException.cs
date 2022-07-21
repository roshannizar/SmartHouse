using System;

namespace SmartHouse.Shared.Infrastructure.Exceptions
{
    public class InvalidException : Exception
    {
        public InvalidException(string message) : base(message) { }
    }
}
