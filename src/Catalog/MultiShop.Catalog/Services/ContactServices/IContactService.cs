using MultiShop.Catalog.Dtos.ContactDtos;

namespace MultiShop.Catalog.Services.ContactServices
{
    public interface IContactService : IGenericService<ResultContactDto, CreateContactDto, UpdateContactDto, GetByIdContactDto>
    {

    }
}
