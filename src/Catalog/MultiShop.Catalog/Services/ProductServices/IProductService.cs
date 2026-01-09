using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService : IGenericService<ResultProductDto, CreateProductDto, UpdateProductDto, GetByIdProductDto>
    {
    }
}
