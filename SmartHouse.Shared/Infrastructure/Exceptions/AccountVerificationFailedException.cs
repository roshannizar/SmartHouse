using System;

namespace SmartHouse.Shared.Infrastructure.Exceptions
{
    public class AccountVerificationFailedException : Exception
    {
        public AccountVerificationFailedException(string message) : base(message) { }
    }
}
