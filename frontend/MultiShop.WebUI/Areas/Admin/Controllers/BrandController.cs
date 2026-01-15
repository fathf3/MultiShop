using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.BrandDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/Brands");
            if (response.IsSuccessStatusCode)
            {
                var sliders = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(sliders);
                return View(values);
            }

            return View();
        }

        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateBrandDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                "https://localhost:7070/api/Brands",
                content);


            if (!response.IsSuccessStatusCode)
                return BadRequest();

            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7070/api/Brands/{id}");
            if (!response.IsSuccessStatusCode)
                return BadRequest();
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
        [Route("Update/{id}")]
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7070/api/Brands/{id}");
            if (response.IsSuccessStatusCode)
            {
                var Brand = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<UpdateBrandDto>(Brand);
                return View(dto);
            }
            return View();
        }
        [Route("Update/{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7070/api/Brands/{dto.Id}", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }

            return View(dto);
        }
    }
}
