using System;

namespace AbiokaDDD.ApplicationService.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Initials { get; set; }

        public string ImageUrl { get; set; }
    }
}
