using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Attributes;

namespace MultiShop.Catalog.Entities
{
    [BsonCollection("Categories")]
    public class Category : BaseEntity
    {
       
        public string CategoryName { get; set; }

    }
}

