using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Commands
{
    public class CreateAddressCommand
    {

            public string FullName { get; set; }
            public string AddresseLine1 { get; set; }
            public string? AddresseLine2 { get; set; }
            public string City { get; set; }
            public string? State { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public bool IsDefault { get; set; }
            public int UserId { get; set; } 

        }
    }


