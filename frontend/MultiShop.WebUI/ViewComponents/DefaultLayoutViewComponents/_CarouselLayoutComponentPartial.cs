using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultLayoutViewComponents
{
    public class _CarouselLayoutComponentPartial : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public _CarouselLayoutComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

    

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureSliderService.GetAllAsync();

            return View(values);
        }
    }
}
