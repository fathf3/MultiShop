using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressQueries;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _addressRepository;
        public GetAddressByIdQueryHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<GetAddressQueryByIdResult> Handle(GetAddressByIdQuery request)
        {
            var address = await _addressRepository.GetByIdAsync(request.Id);
            return new GetAddressQueryByIdResult
            {
                Id = address.Id,
                UserId = address.UserId,
                City = address.City,
                District = address.District,
                Detail = address.Detail
            };
        }
    }
}
