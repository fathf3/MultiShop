using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("UpdateProductDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/ProductDetails/GetProductDetailByProductId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("UpdateProductDetail/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductDetail(string detailId,
    [FromForm] UpdateProductDetailDto dto)
        {
            // Debug için: dto.Id'nin dolu geldiğinden emin olun
            if (string.IsNullOrEmpty(dto.Id))
            {
                ModelState.AddModelError("", "ID bilgisi eksik.");
                return View(dto);
            }

            dto.Id = detailId;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");


            var response = await client.PutAsync($"https://localhost:7070/api/ProductDetails/{dto.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }

            // Hata detayını görmek için:
            var errorContent = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError("", $"API Hatası: {response.StatusCode} - {errorContent}");

            return View(dto);
        }
    }
}
