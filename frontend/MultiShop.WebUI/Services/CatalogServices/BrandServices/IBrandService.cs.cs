using MultiShop.DtoLayer.Dtos.BrandDtos;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandService : IGenericService<
        ResultBrandDto,
        CreateBrandDto,
        UpdateBrandDto>
    {
    }
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
