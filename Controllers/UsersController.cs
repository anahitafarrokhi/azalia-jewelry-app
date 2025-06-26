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
    public class UsersController : Controller
    {
        private readonly CreateUserHandler _createUserHandler;
        private readonly DeleteUserHandler _deleteUserHandler;
        private readonly UpdateUserHandler _updateUserHandler;
        private readonly GetAllUserHandler _getAllUserHandler;
        private readonly GetUserByIdHandler _getUserByIdHandler;
        public UsersController(CreateUserHandler createUserHandler, DeleteUserHandler deleteUserHandler,
            UpdateUserHandler updateUserHandler, GetAllUserHandler getAllUserHandler, GetUserByIdHandler getUserByIdHandler)
        {
            _createUserHandler = createUserHandler;
            _deleteUserHandler = deleteUserHandler;
            _updateUserHandler = updateUserHandler;
            _getAllUserHandler = getAllUserHandler;
            _getUserByIdHandler = getUserByIdHandler;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            await _createUserHandler.Handle(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            await _updateUserHandler.Handle(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteUserHandler.Handle(new DeleteUserCommand { Id = id });
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _getUserByIdHandler.Handle(new GetUserByIdQuery { Id = id });
            return user == null ? NotFound() : Ok(user);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _getAllUserHandler.Handle();
            return Ok(users);
        }

    }
}
