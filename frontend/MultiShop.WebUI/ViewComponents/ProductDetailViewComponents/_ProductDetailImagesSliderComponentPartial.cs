using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImagesSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailImagesSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View(new GetByIdProductImageDto());
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7070/api/ProductImages/GetImageByProductId/{id}");

            if (response.IsSuccessStatusCode)
            {
                var datas = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdProductImageDto>(datas);

                // Eğer values null ise yeni bir örnek gönder
                return View(values ?? new GetByIdProductImageDto());
            }

            return View(new GetByIdProductImageDto());
        }
    }
}
