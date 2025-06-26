using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Commands
{
    public class CreatePaymentCommand
    {

        public int OrdersId { get; set; }
        public PaymentsMethod PaymentsMethod { get; set; }
        public decimal Amount { get; set; }
        public PaymentsStatus PaymentsStatus { get; set; }

    }
}


