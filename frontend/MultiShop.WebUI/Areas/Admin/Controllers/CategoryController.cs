using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _CategoryService;

        public CategoryController(ICategoryService CategoryService)
        {

            _CategoryService = CategoryService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _CategoryService.GetAllAsync();

            return View(values);
        }

        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            await _CategoryService.CreateAsync(dto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _CategoryService.DeleteAsync(id);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
        [Route("Update/{id}")]
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var values = await _CategoryService.GetByIdAsync(id);
            return View();
        }
        [Route("Update/{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto dto)
        {
            await _CategoryService.UpdateAsync(dto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}