using System.ComponentModel.DataAnnotations;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Commands
{
    public class UpdatePaymentCommand
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public PaymentsMethod PaymentsMethod { get; set; }
        public decimal Amount { get; set; }
        public PaymentsStatus PaymentsStatus { get; set; }

    }
}
