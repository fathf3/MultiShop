using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Attributes;

namespace MultiShop.Catalog.Entities
{
    [BsonCollection("ProductDetails")]
    public class ProductDetail : BaseEntity
    {
        
        public string ProducrDescription { get; set; }
        public string ProductInfo { get; set; }
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}

