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
    public class UpdateAddressHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateAddressHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateAddressCommand command)
        {
            var address = await _unitOfWork.Addresses.GetByIdAsync(command.Id);
            if (address == null)
                throw new Exception("Address not found");


            address.FullName = command.FullName;
            address.AddresseLine1 = command.AddresseLine1;
            address.AddresseLine2 = command.AddresseLine2;
            address.City = command.City;
            address.State = command.State;
            address.PostalCode = command.PostalCode;
            address.Country = command.Country;
            address.IsDefault = command.IsDefault;

            _unitOfWork.Addresses.Update(address);
            await _unitOfWork.SaveChangesAsync();


        }
    }
}