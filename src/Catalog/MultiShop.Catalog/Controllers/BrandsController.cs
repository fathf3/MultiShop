using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Services.BrandServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _BrandService;

        public BrandsController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _BrandService.GetAllAsync();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var values = await _BrandService.GetByIdAsync(id);

            if (values == null)
                return NotFound();

            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _BrandService.CreateAsync(dto);

            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateBrandDto dto)
        {

            await _BrandService.UpdateAsync(dto);

            return Ok($"{dto.Id} Başarıyla güncellendi");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _BrandService.DeleteAsync(id);
            return Ok($"{id} Başarıyla silindi");
        }
    }
}
