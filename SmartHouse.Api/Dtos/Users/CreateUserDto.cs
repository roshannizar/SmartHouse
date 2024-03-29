﻿using System.ComponentModel.DataAnnotations;

namespace SmartHouse.Api.Dtos.Users
{
    public class CreateUserDto
    {
        [EmailAddress]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
