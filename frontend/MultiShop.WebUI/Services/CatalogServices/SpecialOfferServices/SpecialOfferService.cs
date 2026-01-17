using MultiShop.DtoLayer.Dtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService
   : GenericService<
       ResultSpecialOfferDto,
       CreateSpecialOfferDto,
       UpdateSpecialOfferDto>,
     ISpecialOfferService
    {
        public SpecialOfferService(HttpClient httpClient)
            : base(httpClient, "SpecialOffers")
        {
        }
    }
}
