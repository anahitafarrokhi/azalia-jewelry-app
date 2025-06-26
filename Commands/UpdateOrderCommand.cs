using AzaliaJwellery.Models;

namespace AzaliaJwellery.Commands
{
    public class UpdateOrderCommand
    {
        public int Id { get; set; }
        public OrdersStatus Status { get; set; }
        public OrderDetailComm OrderDetails { get; set; } = new OrderDetailComm();



        public class OrderDetailComm
        {
            public int Quantity { get; set; }

        }
    }
}
