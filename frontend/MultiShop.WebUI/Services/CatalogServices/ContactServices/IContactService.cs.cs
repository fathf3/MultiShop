using MultiShop.DtoLayer.Dtos.ContactDtos;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService : IGenericService<
        ResultContactDto,
        CreateContactDto,
        UpdateContactDto>
    {
    }
}
