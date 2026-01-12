using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CategoryDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/categories");
            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categories);
                return View(values);
            }

            return View();
        }
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(
                JsonConvert.SerializeObject(dto),
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync(
                "https://localhost:7070/api/categories",
                content);

            if (!response.IsSuccessStatusCode)
                return BadRequest();

            return Ok();
        }
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7070/api/categories/{id}");
            if (!response.IsSuccessStatusCode)
                return BadRequest();
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7070/api/categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                var category = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<UpdateCategoryDto>(category);
                return View(dto);
            }
            return View();
        }
        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7070/api/categories", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }

            return View(dto);
        }
    }
}