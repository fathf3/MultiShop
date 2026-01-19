using MultiShop.DtoLayer.Dtos.ProductDtos;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService
  : GenericService<
      ResultProductDto,
      CreateProductDto,
      UpdateProductDto>,
    IProductService
    {
        public ProductService(HttpClient httpClient)
            : base(httpClient, "Products")
        {
        }
        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<List<ResultProductWithCategoryDto>>(
                    "Products/GetProductsWithCategory");
        }

        public async Task<List<ResultProductWithCategoryDto>>
            GetProductsWithCategoryByCategoryIdAsync(string categoryId)
        {
            return await _httpClient
                .GetFromJsonAsync<List<ResultProductWithCategoryDto>>(
                    $"Products/GetProductsWithCategoryById/{categoryId}");
        }

    }
}
