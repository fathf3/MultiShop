using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _FeatureSliderService;

        public FeatureSlidersController(IFeatureSliderService FeatureSliderService)
        {
            _FeatureSliderService = FeatureSliderService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _FeatureSliderService.GetAllAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var FeatureSlider = await _FeatureSliderService.GetByIdAsync(id);

            if (FeatureSlider == null)
                return NotFound();

            return Ok(FeatureSlider);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFeatureSliderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _FeatureSliderService.CreateAsync(dto);

            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateFeatureSliderDto dto)
        {

            await _FeatureSliderService.UpdateAsync(dto);

            return Ok($"{dto.Id} Başarıyla güncellendi");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _FeatureSliderService.DeleteAsync(id);
            return Ok($"{id} Başarıyla silindi");
        }

        
    }
}
