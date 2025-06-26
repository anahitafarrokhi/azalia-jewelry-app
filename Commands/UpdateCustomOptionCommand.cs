using System.ComponentModel.DataAnnotations;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Commands
{
    public class UpdateCustomOptionCommand
    {
        public int Id { get; set; }
        public string OptionName { get; set; }
        public string OptionValue { get; set; }

    }
}
