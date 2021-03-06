using System;
using System.ComponentModel.DataAnnotations;
using BCrypt.Net;

namespace FoodooBackend.Models
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Account()
        {
        }
        public Account(string email, string username, string password)
        {
            Email = email;
            Username = username;
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool ValidatePassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
        
        
        
    }
}