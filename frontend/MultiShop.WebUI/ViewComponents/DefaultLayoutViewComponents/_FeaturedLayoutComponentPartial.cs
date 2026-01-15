using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.DefaultLayoutViewComponents
{
    public class _FeaturedLayoutComponentPartial : ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
