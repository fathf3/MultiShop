using AutoMapper;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;

namespace MultiShop.Catalog.Services.BrandServices
{
    public class BrandService
    : GenericService<
        Brand,
        ResultBrandDto,
        CreateBrandDto,
        UpdateBrandDto,
        GetByIdBrandDto>,
      IBrandService
    {
        public BrandService(
            IMongoRepository<Brand> repository,
            IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
