using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.Dtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _FeatureSliderService;

        public FeatureSliderController(IFeatureSliderService FeatureSliderService)
        {

            _FeatureSliderService = FeatureSliderService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _FeatureSliderService.GetAllAsync();

            return View(values);
        }

        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateFeatureSliderDto dto)
        {
            await _FeatureSliderService.CreateAsync(dto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _FeatureSliderService.DeleteAsync(id);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
        [Route("Update/{id}")]
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var values = await _FeatureSliderService.GetByIdAsync(id);
            return View();
        }
        [Route("Update/{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureSliderDto dto)
        {
            await _FeatureSliderService.UpdateAsync(dto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
    }
}
