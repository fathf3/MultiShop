using MultiShop.DtoLayer.Dtos.CategoryDtos;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService
    : GenericService<
        ResultCategoryDto,
        CreateCategoryDto,
        UpdateCategoryDto>,
      ICategoryService
    {
        public CategoryService(HttpClient httpClient)
            : base(httpClient, "Categories")
        {
        }
    }
}
