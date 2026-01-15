using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductServices;

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
            IMapper mapper
           )
            : base(repository, mapper)
        {
            
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values =  _collection
                .Find<ProductDetail>(x => x.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var value = await  _collection
                .Find(x => x.ProductId == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<GetByIdProductDetailDto>(value);
        }
    }
}
