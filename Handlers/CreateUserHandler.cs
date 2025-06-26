using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Handlers
{
    public class CreateUserHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateUserCommand command)
        {


            var user = new Users()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                MobileNumber = command.MobileNumber,
                PasswordHash = command.PasswordHash,
                SentNewsOrNot = command.SentNewsOrNot
            };
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
