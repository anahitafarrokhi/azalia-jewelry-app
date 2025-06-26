using System.ComponentModel.DataAnnotations;
using AzaliaJwellery.Models;
using Microsoft.AspNetCore.Components.Web;

namespace AzaliaJwellery.Commands
{
    public class UpdateUserCommand
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string PasswordHash { get; set; }
        public bool SentNewsOrNot { get; set; }

        
    }
}
