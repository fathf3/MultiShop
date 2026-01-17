using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _ProductImageService;

        public ProductImageController(IProductImageService ProductImageService)
        {

            _ProductImageService = ProductImageService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _ProductImageService.GetAllAsync();

            return View(values);
        }

        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateProductImageDto dto)
        {
            await _ProductImageService.CreateAsync(dto);
            return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ProductImageService.DeleteAsync(id);
            return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
        }
        [Route("Update/{id}")]
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var values = await _ProductImageService.GetByIdAsync(id);
            return View();
        }
        [Route("Update/{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductImageDto dto)
        {
            await _ProductImageService.UpdateAsync(dto);
            return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
        }
    }
}
