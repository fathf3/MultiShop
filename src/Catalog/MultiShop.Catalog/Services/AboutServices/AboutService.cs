using AutoMapper;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;

namespace MultiShop.Catalog.Services.AboutServices
{
    public class AboutService
   : GenericService<
       About,
       ResultAboutDto,
       CreateAboutDto,
       UpdateAboutDto,
       GetByIdAboutDto>,
     IAboutService
    {
        public AboutService(
            IMongoRepository<About> repository,
            IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
