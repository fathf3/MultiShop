using MultiShop.DtoLayer.Dtos.BrandDtos;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService
   : GenericService<
       ResultBrandDto,
       CreateBrandDto,
       UpdateBrandDto>,
     IBrandService
    {
        public BrandService(HttpClient httpClient)
            : base(httpClient, "Brands")
        {
        }
    }
}
