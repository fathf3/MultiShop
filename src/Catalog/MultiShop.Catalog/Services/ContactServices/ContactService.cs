using AutoMapper;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService
   : GenericService<
       Contact,
       ResultContactDto,
       CreateContactDto,
       UpdateContactDto,
       GetByIdContactDto>,
     IContactService
    {
        public ContactService(
            IMongoRepository<Contact> repository,
            IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
