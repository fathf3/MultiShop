using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _SpecialOfferService;

        public SpecialOffersController(ISpecialOfferService SpecialOfferService)
        {
            _SpecialOfferService = SpecialOfferService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _SpecialOfferService.GetAllAsync();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var values = await _SpecialOfferService.GetByIdAsync(id);

            if (values == null)
                return NotFound();

            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSpecialOfferDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _SpecialOfferService.CreateAsync(dto);

            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateSpecialOfferDto dto)
        {

            await _SpecialOfferService.UpdateAsync(dto);

            return Ok($"{dto.Id} Başarıyla güncellendi");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _SpecialOfferService.DeleteAsync(id);
            return Ok($"{id} Başarıyla silindi");
        }


    }
}
