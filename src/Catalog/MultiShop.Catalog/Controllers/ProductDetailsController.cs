using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _productDetailService.GetAllAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var productDetail = await _productDetailService.GetByIdAsync(id);

            if (productDetail == null)
                return NotFound();

            return Ok(productDetail);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDetailDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productDetailService.CreateAsync(dto);

            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateProductDetailDto dto)
        {

            await _productDetailService.UpdateAsync(dto);

            return Ok($"{dto.Id} Başarıyla güncellendi");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productDetailService.DeleteAsync(id);
            return Ok($"{id} Başarıyla silindi");
        }
    }
}
