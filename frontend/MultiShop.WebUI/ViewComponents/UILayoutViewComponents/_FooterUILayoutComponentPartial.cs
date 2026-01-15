using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.AboutDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    { 
        private readonly IHttpClientFactory _clientFactory;

        public _FooterUILayoutComponentPartial(IHttpClientFactory ClientFactory)
        {
            _clientFactory = ClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/Abouts");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(data);
                return View(values);
            }

            return View();
        }
    }
}
