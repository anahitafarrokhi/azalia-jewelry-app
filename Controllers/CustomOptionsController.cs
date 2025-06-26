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
    public class CustomOptionsController : Controller
    {
        private readonly CreateCustomOptionHandler _createCustomOptionHandler;
        private readonly DeleteCustomOptionHandler _deleteCustomOptionHandler;
        private readonly UpdateCustomOptionHandler _updateCustomOptionHandler;
        private readonly GetAllCustomOptionesByUserIdHandler _GetAllCustomOptionesByUserIdHandler;
        private readonly GetCustomOptionByIdHandler _getCustomOptionByIdHandler;
        public CustomOptionsController(CreateCustomOptionHandler createCustomOptionHandler, DeleteCustomOptionHandler deleteCustomOptionHandler,
            UpdateCustomOptionHandler updateCustomOptionHandler, GetAllCustomOptionesByUserIdHandler getAllCustomOptionesByUserIdHandler, GetCustomOptionByIdHandler getCustomOptionByIdHandler)
        {
            _createCustomOptionHandler = createCustomOptionHandler;
            _deleteCustomOptionHandler = deleteCustomOptionHandler;
            _updateCustomOptionHandler = updateCustomOptionHandler;
            _GetAllCustomOptionesByUserIdHandler = getAllCustomOptionesByUserIdHandler;
            _getCustomOptionByIdHandler = getCustomOptionByIdHandler;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomOptionCommand command)
        {
            await _createCustomOptionHandler.Handle(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomOptionCommand command)
        {
            await _updateCustomOptionHandler.Handle(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteCustomOptionHandler.Handle(new DeleteCustomOptionCommand { Id = id });
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomizationOption>> GetById(int id)
        {
            var address = await _getCustomOptionByIdHandler.Handle(new GetCustomOptionsByIdQuery { Id = id });
            return address == null ? NotFound() : Ok(address);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomizationOption>>> GetAll(int id)
        {
            var customOptione = await _GetAllCustomOptionesByUserIdHandler.Handle(new GetAllCustomOptionsByProductIdQuery { ProductId = id });
            return Ok(customOptione);
        }

    }
}
