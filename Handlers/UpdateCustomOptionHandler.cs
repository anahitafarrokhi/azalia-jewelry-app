using System.Diagnostics.Metrics;
using System.Drawing.Text;
using AzaliaJwellery.Commands;
using AzaliaJwellery.Interfaces;
using AzaliaJwellery.Models;
using AzaliaJwellery.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Mono.TextTemplating;

namespace AzaliaJwellery.Handlers
{
    public class UpdateCustomOptionHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCustomOptionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateCustomOptionCommand command)
        {
            var address = await _unitOfWork.CustomOption.GetByIdAsync(command.Id);
            if (address == null)
                throw new Exception("CustomOption not found");


            address.OptionName = command.OptionName;
            address.OptionValue = command.OptionValue;
            

            _unitOfWork.CustomOption.Update(address);
            await _unitOfWork.SaveChangesAsync();


        }
    }
}