using MultiShop.DtoLayer.Dtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferService : IGenericService<
        ResultSpecialOfferDto,
        CreateSpecialOfferDto,
        UpdateSpecialOfferDto>
    {
    }
}
