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
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public CreateAddressCommandHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task Handle(CreateAddressCommand request)
        {
            

            Address newAddress = new Address
            {
                UserId = request.UserId,
                District = request.District,
                City = request.City,
                Detail = request.Detail
            };
            await _addressRepository.AddAsync(newAddress);
        }


    }
}
