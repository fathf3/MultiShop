using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultLayoutViewComponents
{
    public class _VendorLayoutComponentPartial : ViewComponent
    {
        private readonly IBrandService _branService;

        public _VendorLayoutComponentPartial(IBrandService branService)
        {
            _branService = branService;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _branService.GetAllAsync();

            return View(values);
        }
    }
}
