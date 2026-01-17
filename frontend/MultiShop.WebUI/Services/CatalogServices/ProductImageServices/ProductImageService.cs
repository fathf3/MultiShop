using MultiShop.DtoLayer.Dtos.ProductImageDtos;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService
  : GenericService<
      ResultProductImageDto,
      CreateProductImageDto,
      UpdateProductImageDto>,
    IProductImageService
    {
        public ProductImageService(HttpClient httpClient)
            : base(httpClient, "ProductImages")
        {
        }
    }
}
