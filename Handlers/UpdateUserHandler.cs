using System.Drawing.Text;
using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace AzaliaJwellery.Handlers
{
    public class UpdateUserHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateUserCommand command)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(command.Id);
            if (user == null)
                throw new Exception("User not found");
            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.Email = command.Email;
            user.MobileNumber = command.MobileNumber;
            user.SentNewsOrNot = command.SentNewsOrNot;
            user.PasswordHash = command.PasswordHash;

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();
            

        }
    }
}
