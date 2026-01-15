using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Services.AboutServices
{
    public interface IAboutService : IGenericService<ResultAboutDto, CreateAboutDto, UpdateAboutDto, GetByIdAboutDto>
    {

    }
}
