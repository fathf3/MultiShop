using AutoMapper;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService
     : GenericService<
         ProductImage,
         ResultProductImageDto,
         CreateProductImageDto,
         UpdateProductImageDto,
         GetByIdProductImageDto>,
       IProductImageService
    {
        public ProductImageService(
            IMongoRepository<ProductImage> repository,
            IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
