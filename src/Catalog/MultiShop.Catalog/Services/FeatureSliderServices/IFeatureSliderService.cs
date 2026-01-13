using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService : IGenericService<ResultFeatureSliderDto, CreateFeatureSliderDto, UpdateFeatureSliderDto, GetByIdFeatureSliderDto>
    {
        Task FeatureSliderChangeStatusToTrue(string id);
        Task FeatureSliderChangeStatusToFalse(string id);
    }
}
