using MultiShop.DtoLayer.Dtos.ContactDtos;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService
  : GenericService<
      ResultContactDto,
      CreateContactDto,
      UpdateContactDto>,
    IContactService
    {
        public ContactService(HttpClient httpClient)
            : base(httpClient, "Contacts")
        {
        }
    }
}
