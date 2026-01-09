using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService : IGenericService<ResultCategoryDto, CreateCategoryDto, UpdateCategoryDto, GetByIdCategoryDto>
    {
   
    }
}
