using MultiShop.DtoLayer.Dtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public interface IFeatureSliderService : IGenericService<
         ResultFeatureSliderDto,
         CreateFeatureSliderDto,
         UpdateFeatureSliderDto>
    {
    }
}
