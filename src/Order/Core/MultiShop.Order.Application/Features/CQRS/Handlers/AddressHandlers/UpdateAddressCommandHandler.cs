using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _addressRepository;
        public UpdateAddressCommandHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task Handle(UpdateAddressCommand address)
        {
            var value = await _addressRepository.GetByIdAsync(address.Id);
            value.UserId = address.UserId;
            value.District = address.District;
            value.City = address.City;
            value.Detail = address.Detail;
            await _addressRepository.UpdateAsync(value);
        }
    }
}
