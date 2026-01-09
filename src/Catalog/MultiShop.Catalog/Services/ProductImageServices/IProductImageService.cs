using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService : IGenericService<ResultProductImageDto, CreateProductImageDto, UpdateProductImageDto, GetByIdProductImageDto>
    {
    }
}
