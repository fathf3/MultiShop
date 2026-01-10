using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task Handle(CreateOrderDetailCommand orderDetail)
        {
            OrderDetail newOrderDetail = new OrderDetail
            {
                ProductName = orderDetail.ProductName,
                ProductId = orderDetail.ProductId,
                Price = orderDetail.Price,
                Amount = orderDetail.Amount,
                TotalPrice = orderDetail.TotalPrice,
                OrderingId = orderDetail.OrderingId
            };
            await _orderDetailRepository.AddAsync(newOrderDetail);

        }

    }
}
