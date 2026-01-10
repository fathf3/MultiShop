using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _orderDetailRepository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                Id = values.Id,
                ProductName = values.ProductName,
                ProductId = values.ProductId,
                Price = values.Price,
                Amount = values.Amount,
                TotalPrice = values.TotalPrice,
                OrderingId = values.OrderingId
            };

        }
    }
}
