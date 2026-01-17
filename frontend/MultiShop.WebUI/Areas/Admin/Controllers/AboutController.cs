using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IAboutService _AboutService;
       
        public AboutController(IAboutService aboutService)
        {
            
            _AboutService = aboutService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _AboutService.GetAllAsync();

            return View(values);
        }

        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateAboutDto dto)
        {
            await _AboutService.CreateAsync(dto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _AboutService.DeleteAsync(id);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
        [Route("Update/{id}")]
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var values = await _AboutService.GetByIdAsync(id);
            return View();
        }
        [Route("Update/{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto dto)
        {
            await _AboutService.UpdateAsync(dto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
    }
}
