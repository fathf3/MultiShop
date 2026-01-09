using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService : IGenericService<ResultProductDetailDto, CreateProductDetailDto, UpdateProductDetailDto, GetByIdProductDetailDto>
    {
    }
}
