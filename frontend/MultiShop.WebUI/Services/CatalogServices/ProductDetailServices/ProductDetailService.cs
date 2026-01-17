using MultiShop.DtoLayer.Dtos.ProductDetailDtos;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService
  : GenericService<
      ResultProductDetailDto,
      CreateProductDetailDto,
      UpdateProductDetailDto>,
    IProductDetailService
    {
        public ProductDetailService(HttpClient httpClient)
            : base(httpClient, "ProductDetails")
        {
        }
    }
}
