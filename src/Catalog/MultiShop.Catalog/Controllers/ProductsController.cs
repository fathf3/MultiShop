using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _productService.GetAllAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var Product = await _productService.GetByIdAsync(id);

            if (Product == null)
                return NotFound();

            return Ok(Product);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productService.CreateAsync(dto);

            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto dto)
        {

            await _productService.UpdateAsync(dto);

            return Ok($"{dto.Id} Başarıyla güncellendi");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.DeleteAsync(id);
            return Ok($"{id} Başarıyla silindi");
        }
    }
}
