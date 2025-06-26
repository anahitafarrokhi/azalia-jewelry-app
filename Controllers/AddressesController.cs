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
    public class AddressesController : Controller
    {
        private readonly CreateAddressHandler _createAddressHandler;
        private readonly DeleteAddressHandler _deleteAddressHandler;
        private readonly UpdateAddressHandler _updateAddressHandler;
        private readonly GetAllAddressesByUserIdHandler _GetAllAddressesByUserIdHandler;
        private readonly GetAddressByIdHandler _getAddressByIdHandler;
        public AddressesController(CreateAddressHandler createAddressHandler, DeleteAddressHandler deleteAddressHandler,
            UpdateAddressHandler updateAddressHandler, GetAllAddressesByUserIdHandler getAllAddressesByUserIdHandler, GetAddressByIdHandler getAddressByIdHandler)
        {
            _createAddressHandler = createAddressHandler;
            _deleteAddressHandler = deleteAddressHandler;
            _updateAddressHandler = updateAddressHandler;
            _GetAllAddressesByUserIdHandler = getAllAddressesByUserIdHandler;
            _getAddressByIdHandler = getAddressByIdHandler;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAddressCommand command)
        {
            await _createAddressHandler.Handle(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAddressCommand command)
        {
            await _updateAddressHandler.Handle(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteAddressHandler.Handle(new DeleteAddressCommand { Id = id });
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Addresses>> GetById(int id)
        {
            var address = await _getAddressByIdHandler.Handle(new GetAddressByIdQuery { Id = id });
            return address == null ? NotFound() : Ok(address);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Addresses>>> GetAll(int id)
        {
            var addresses = await _GetAllAddressesByUserIdHandler.Handle(new GetAllAddressesByUserIdQuery { UserId = id });
            return Ok(addresses);
        }

    }
}
