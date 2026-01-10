using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _categoryService.CreateAsync(dto);

            return StatusCode(StatusCodes.Status201Created);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto dto)
        {
         
            await _categoryService.UpdateAsync(dto);

            return Ok($"{dto.Id} Başarıyla güncellendi");
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok($"{id} Başarıyla silindi");
        }
    }
}
