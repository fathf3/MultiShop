using AutoMapper;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService
  : GenericService<
      SpecialOffer,
      ResultSpecialOfferDto,
      CreateSpecialOfferDto,
      UpdateSpecialOfferDto,
      GetByIdSpecialOfferDto>,
    ISpecialOfferService
    {
        public SpecialOfferService(
            IMongoRepository<SpecialOffer> repository,
            IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
