using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Commands
{
    public class CreateJewelleryTypeCommand
    {

            public string Name { get; set; }
            public string? Desc { get; set; }

        }
    }


