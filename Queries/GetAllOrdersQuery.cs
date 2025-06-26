
using System.ComponentModel.DataAnnotations;

namespace AzaliaJwellery.Queries
{
    public class GetAllOrdersQuery
    {
    }
    public class OrderDto
    {
        [Key]
        public int Id { get; set; }
        public UserDto User { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public OrderDetailDto OrderDetail { get; set; }
    }
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string LastName { get; set; }
        public bool SentNewsOrNot { get; set; }
        

    }
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public  ProductDto ProductDto { get; set; }


    }
}
