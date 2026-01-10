namespace MultiShop.Order.Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }

        public int OrderingId { get; set; }
        public Ordering Ordering { get; set; }

    }
}
