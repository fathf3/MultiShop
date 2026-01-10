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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(command.Id);

            orderDetail.ProductName = command.ProductName;
            orderDetail.ProductId = command.ProductId;
            orderDetail.Price = command.Price;
            orderDetail.Amount = command.Amount;
            orderDetail.TotalPrice = command.TotalPrice;
            orderDetail.OrderingId = command.OrderingId;
            await _orderDetailRepository.UpdateAsync(orderDetail);

        }
    }
}
