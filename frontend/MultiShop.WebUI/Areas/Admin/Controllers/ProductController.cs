using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.Dtos.CategoryDtos;
using MultiShop.DtoLayer.Dtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {

            _ProductService = ProductService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _ProductService.GetAllAsync();

            return View(values);
        }

        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            await _ProductService.CreateAsync(dto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ProductService.DeleteAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        [Route("Update/{id}")]
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var values = await _ProductService.GetByIdAsync(id);
            return View();
        }
        [Route("Update/{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            await _ProductService.UpdateAsync(dto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}
    

