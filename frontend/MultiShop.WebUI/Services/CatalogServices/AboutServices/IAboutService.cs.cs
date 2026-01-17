using MultiShop.DtoLayer.Dtos.AboutDtos;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService : IGenericService<
        ResultAboutDto,
        CreateAboutDto,
        UpdateAboutDto>
    {
    }
}
