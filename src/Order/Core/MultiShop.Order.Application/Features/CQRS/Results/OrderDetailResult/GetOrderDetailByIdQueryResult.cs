using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResult
{
    public class GetOrderDetailByIdQueryResult
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }

        public int OrderingId { get; set; }
    }
}
