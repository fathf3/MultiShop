using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IBrandService _BrandService;

        public BrandController(IBrandService BrandService)
        {

            _BrandService = BrandService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _BrandService.GetAllAsync();

            return View(values);
        }

        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateBrandDto dto)
        {
            await _BrandService.CreateAsync(dto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _BrandService.DeleteAsync(id);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
        [Route("Update/{id}")]
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var values = await _BrandService.GetByIdAsync(id);
            return View();
        }
        [Route("Update/{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandDto dto)
        {
            await _BrandService.UpdateAsync(dto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
    }
}
