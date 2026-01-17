using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _ProductDetailService;

        public ProductDetailController(IProductDetailService ProductDetailService)
        {

            _ProductDetailService = ProductDetailService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _ProductDetailService.GetAllAsync();

            return View(values);
        }

        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateProductDetailDto dto)
        {
            await _ProductDetailService.CreateAsync(dto);
            return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ProductDetailService.DeleteAsync(id);
            return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
        }
        [Route("Update/{id}")]
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var values = await _ProductDetailService.GetByIdAsync(id);
            return View();
        }
        [Route("Update/{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDetailDto dto)
        {
            await _ProductDetailService.UpdateAsync(dto);
            return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
        }
    }
}
