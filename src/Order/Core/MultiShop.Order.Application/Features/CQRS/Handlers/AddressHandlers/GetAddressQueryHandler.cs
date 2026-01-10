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
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public GetAddressQueryHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _addressRepository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                Id = x.Id,
                UserId = x.UserId,
                City = x.City,
                District = x.District,
                Detail = x.Detail
            }).ToList();
        }
    }
}
