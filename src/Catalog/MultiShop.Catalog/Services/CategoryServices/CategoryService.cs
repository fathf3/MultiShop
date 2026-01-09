using AutoMapper;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService
    : GenericService<
        Category,
        ResultCategoryDto,
        CreateCategoryDto,
        UpdateCategoryDto,
        GetByIdCategoryDto>,
      ICategoryService
    {
        public CategoryService(
            IMongoRepository<Category> repository,
            IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
