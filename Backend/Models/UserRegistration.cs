﻿namespace PhoneVault.Models;

public class UserRegistration
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}