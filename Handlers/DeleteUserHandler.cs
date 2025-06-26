using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;

namespace AzaliaJwellery.Handlers
{
    public class DeleteUserHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public DeleteUserHandler( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteUserCommand command)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(command.Id);
            if (user == null) {
                throw new Exception("User not found");
            }
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
