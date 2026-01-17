using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _SpecialOfferService;

        public SpecialOfferController(ISpecialOfferService SpecialOfferService)
        {

            _SpecialOfferService = SpecialOfferService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _SpecialOfferService.GetAllAsync();

            return View(values);
        }

        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateSpecialOfferDto dto)
        {
            await _SpecialOfferService.CreateAsync(dto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _SpecialOfferService.DeleteAsync(id);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
        [Route("Update/{id}")]
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var values = await _SpecialOfferService.GetByIdAsync(id);
            return View();
        }
        [Route("Update/{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSpecialOfferDto dto)
        {
            await _SpecialOfferService.UpdateAsync(dto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
    }
}
