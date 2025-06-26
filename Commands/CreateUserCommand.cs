using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AzaliaJwellery.Models;
using static AzaliaJwellery.Commands.CreateProductCommand;

namespace AzaliaJwellery.Commands
{
    public class CreateUserCommand
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string PasswordHash { get; set; }
        public bool SentNewsOrNot { get; set; }
        

    }
}

