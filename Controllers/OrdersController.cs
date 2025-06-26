using AzaliaJwellery.Commands;
using AzaliaJwellery.Handlers;
using AzaliaJwellery.Models;
using AzaliaJwellery.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static NuGet.Packaging.PackagingConstants;

namespace AzaliaJwellery.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private readonly CreateOrderHandler _createOrderHandler;
        private readonly DeleteOrderHandler _deleteOrderHandler;
        private readonly UpdateOrderHandler _updateOrderHandler;
        private readonly GetAllOrderHandler _getAllOrderHandler;
        private readonly GetOrderByIdHandler _getOrderByIdHandler;
        public OrdersController(CreateOrderHandler createOrderHandler, DeleteOrderHandler deleteOrderHandler,
            UpdateOrderHandler updateOrderHandler, GetAllOrderHandler getAllOrderHandler, GetOrderByIdHandler getOrderByIdHandler)
        {
            _createOrderHandler = createOrderHandler;
            _deleteOrderHandler = deleteOrderHandler;
            _updateOrderHandler = updateOrderHandler;
            _getAllOrderHandler = getAllOrderHandler;
            _getOrderByIdHandler = getOrderByIdHandler;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            await _createOrderHandler.Handle(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommand command)
        {
            await _updateOrderHandler.Handle(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteOrderHandler.Handle(new DeleteOrderCommand { Id = id });
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var order = await _getOrderByIdHandler.Handle(new GetOrderByIdQuery { Id = id });
            return order == null ? NotFound() : Ok(order);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
        {
            var orders = await _getAllOrderHandler.Handle();
            return Ok(orders);
        }

    }
}
