using AutoMapper;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService
     : GenericService<
         ProductDetail,
         ResultProductDetailDto,
         CreateProductDetailDto,
         UpdateProductDetailDto,
         GetByIdProductDetailDto>,
       IProductDetailService
    {
        public ProductDetailService(
            IMongoRepository<ProductDetail> repository,
            IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
