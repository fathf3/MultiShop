using AutoMapper;
using MongoDB.Driver;
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

        public async Task<GetByIdProductImageDto> GetImageByProductIdAsync(string productId)
        {
            var image = await _collection
                .Find(x => x.ProductID == productId)
                .FirstOrDefaultAsync();
           
            var map = _mapper.Map<GetByIdProductImageDto>(image);
            
            return map;

        }
    }
}
