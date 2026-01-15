using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService : IGenericService<ResultProductDto, CreateProductDto, UpdateProductDto, GetByIdProductDto>
    {
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByIdAsync(string categoryId);
    }
}
