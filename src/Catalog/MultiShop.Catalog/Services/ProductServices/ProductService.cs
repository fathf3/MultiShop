using AutoMapper;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService
    : GenericService<
        Product,
        ResultProductDto,
        CreateProductDto,
        UpdateProductDto,
        GetByIdProductDto>,
      IProductService
    {
        public ProductService(
            IMongoRepository<Product> repository,
            IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
