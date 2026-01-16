using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactsController(IContactService ContactService)
        {
            _ContactService = ContactService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _ContactService.GetAllAsync();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var values = await _ContactService.GetByIdAsync(id);

            if (values == null)
                return NotFound();

            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _ContactService.CreateAsync(dto);

            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateContactDto dto)
        {

            await _ContactService.UpdateAsync(dto);

            return Ok($"{dto.Id} Başarıyla güncellendi");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ContactService.DeleteAsync(id);
            return Ok($"{id} Başarıyla silindi");
        }
    }
}
