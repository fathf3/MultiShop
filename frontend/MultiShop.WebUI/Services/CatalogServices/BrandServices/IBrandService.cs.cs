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
   
}
