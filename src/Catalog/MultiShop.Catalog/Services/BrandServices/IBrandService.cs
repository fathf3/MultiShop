using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Services.BrandServices;

namespace MultiShop.Catalog.Services.BrandServices
{
    public interface IBrandService : IGenericService<ResultBrandDto, CreateBrandDto, UpdateBrandDto, GetByIdBrandDto>
    {

    }
}
