using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentView : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductListComponentView(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(
                $"https://localhost:7070/api/Products/GetProductsWithCategoryById?categoryId={id}"
            );

            if (response.IsSuccessStatusCode)
            {
                var datas = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(datas);

                return View(values ?? new List<ResultProductWithCategoryDto>());
            }

            
            return View(new List<ResultProductWithCategoryDto>());
        }

    }
}
