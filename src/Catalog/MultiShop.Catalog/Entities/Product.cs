using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Attributes;

namespace MultiShop.Catalog.Entities
{
    [BsonCollection("Products")]
    public class Product : BaseEntity
    {
       
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }
        public string CategoryID { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }

    }
}

