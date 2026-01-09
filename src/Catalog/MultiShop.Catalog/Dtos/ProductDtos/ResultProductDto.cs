using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }

        public string CategoryID { get; set; }
    }
}
