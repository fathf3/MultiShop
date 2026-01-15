using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _AboutService;

        public AboutsController(IAboutService AboutService)
        {
            _AboutService = AboutService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _AboutService.GetAllAsync();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var values = await _AboutService.GetByIdAsync(id);

            if (values == null)
                return NotFound();

            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAboutDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _AboutService.CreateAsync(dto);

            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateAboutDto dto)
        {

            await _AboutService.UpdateAsync(dto);

            return Ok($"{dto.Id} Başarıyla güncellendi");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _AboutService.DeleteAsync(id);
            return Ok($"{id} Başarıyla silindi");
        }
    }
}
