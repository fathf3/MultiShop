using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _productImageService.GetAllAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var productImage = await _productImageService.GetByIdAsync(id);

            if (productImage == null)
                return NotFound();

            return Ok(productImage);
        }

        [HttpGet("GetImageByProductId/{id}")]
        public async Task<IActionResult> GetImageByProductIdAsync(string id)
        {
            var productImage = await _productImageService.GetImageByProductIdAsync(id);

            if (productImage == null)
                return NotFound();

            return Ok(productImage);
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductImageDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productImageService.CreateAsync(dto);

            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateProductImageDto dto)
        {

            await _productImageService.UpdateAsync(dto);

            return Ok($"{dto.Id} Başarıyla güncellendi");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productImageService.DeleteAsync(id);
            return Ok($"{id} Başarıyla silindi");
        }



    }
}
