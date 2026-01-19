using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultLayoutViewComponents
{
    public class _CategoryLayoutComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoryLayoutComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllAsync();

            return View(values);
        }
    }
}
