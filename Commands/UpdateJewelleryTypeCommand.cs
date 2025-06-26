using System.ComponentModel.DataAnnotations;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Commands
{
    public class UpdateJewelleryTypeCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Desc { get; set; }

    }
}
