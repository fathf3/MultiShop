using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService
    : GenericService<
        FeatureSlider,
        ResultFeatureSliderDto,
        CreateFeatureSliderDto,
        UpdateFeatureSliderDto,
        GetByIdFeatureSliderDto>,
      IFeatureSliderService
    {
        public FeatureSliderService(
            IMongoRepository<FeatureSlider> repository,
            IMapper mapper)
            : base(repository, mapper)
        {
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            var values = _collection.Find<FeatureSlider>(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<Task>(values.Result.Status = false);
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            var values = _collection.Find<FeatureSlider>(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<Task>(values.Result.Status = true);
        }
    }
}
