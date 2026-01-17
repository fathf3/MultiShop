using MultiShop.DtoLayer.Dtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService
   : GenericService<
       ResultAboutDto,
       CreateAboutDto,
       UpdateAboutDto>,
     IAboutService
    {
        public AboutService(HttpClient httpClient)
            : base(httpClient, "Abouts")
        {
        }
    }
}
