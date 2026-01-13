using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService : IGenericService<ResultSpecialOfferDto, CreateSpecialOfferDto, UpdateSpecialOfferDto, GetByIdSpecialOfferDto>
    {

    }
}
