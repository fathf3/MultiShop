using MultiShop.DtoLayer.Dtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService
  : GenericService<
      ResultFeatureSliderDto,
      CreateFeatureSliderDto,
      UpdateFeatureSliderDto>,
    IFeatureSliderService
    {
        public FeatureSliderService(HttpClient httpClient)
            : base(httpClient, "FeatureSliders")
        {
        }
    }
}
