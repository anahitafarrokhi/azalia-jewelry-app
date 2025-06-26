using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Commands
{
    public class CreateCustomOptionCommand
    {

            public string OptionName { get; set; }
            public string OptionValue { get; set; }
            public int ProductsId { get; set; } 

        }
    }


