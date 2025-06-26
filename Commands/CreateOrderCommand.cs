using System.ComponentModel.DataAnnotations.Schema;
using AzaliaJwellery.Models;

namespace AzaliaJwellery.Commands
{
    public class CreateOrderCommand
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public MyOrderDetail OrderDetails { get; set; } = new MyOrderDetail();



        public class MyOrderDetail
        {
            public int ProductId { get; set; }
            public decimal Amount { get; set; }
            public int Quantity { get; set; }

        }
    }
}

