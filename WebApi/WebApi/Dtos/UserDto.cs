﻿namespace WebApi.Dtos
{
    public class UserDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string Password{ get; set; }
      
    }
}
