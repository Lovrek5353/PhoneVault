﻿using System.ComponentModel.DataAnnotations;

namespace PhoneVault.Models
{
    public class UserDTO
    {
        public required string Name { get; set; }
        [MaxLength(256)]
        public required string Email { get; set; }
        [MaxLength(1024)]
        public required string Password { get; set; }
        [MaxLength(64)]
        public string? PhoneNumber { get; set; }
        [MaxLength(256)]
        public string? Address { get; set; }
        [MaxLength(64)]
        public string? UserType { get; set; }

        //public required ICollection<Order> Orders { get; set; }
        //public required ShoppingCart ShoppingCart { get; set; }
        //public required ICollection<Review> Reviews { get; set; }

    }
}
