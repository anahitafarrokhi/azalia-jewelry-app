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
    public class PaymentsController : Controller
    {
        private readonly CreatePaymentHandler _createPaymentHandler;
        private readonly DeletePaymentHandler _deletePaymentHandler;
        private readonly UpdatePaymentHandler _updatePaymentHandler;
        private readonly GetAllPaymentHandler _GetAllPaymentHandler;
        private readonly GetPaymentByIdHandler _getPaymentByIdHandler;
        public PaymentsController(CreatePaymentHandler createPaymentHandler, DeletePaymentHandler deletePaymentHandler,
            UpdatePaymentHandler updatePaymentHandler, GetAllPaymentHandler getAllPaymentHandler, GetPaymentByIdHandler getPaymentByIdHandler)
        {
            _createPaymentHandler = createPaymentHandler;
            _deletePaymentHandler = deletePaymentHandler;
            _updatePaymentHandler = updatePaymentHandler;
            _GetAllPaymentHandler = getAllPaymentHandler;
            _getPaymentByIdHandler = getPaymentByIdHandler;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentCommand command)
        {
            await _createPaymentHandler.Handle(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentCommand command)
        {
            await _updatePaymentHandler.Handle(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deletePaymentHandler.Handle(new DeletePaymentCommand { Id = id });
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Payments>> GetById(int id)
        {
            var payment = await _getPaymentByIdHandler.Handle(new GetPaymentByIdQuery { Id = id });
            return payment == null ? NotFound() : Ok(payment);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payments>>> GetAll()
        {
            var payments = await _GetAllPaymentHandler.Handle();
            return Ok(payments);
        }

    }
}
