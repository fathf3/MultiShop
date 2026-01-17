using MultiShop.DtoLayer.Dtos.CategoryDtos;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService : IGenericService<
        ResultCategoryDto,
        CreateCategoryDto,
        UpdateCategoryDto>
    {
    }
}
