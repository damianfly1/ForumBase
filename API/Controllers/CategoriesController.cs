using Application.DTOs;
using Application.DTOs.Category;
using Application.Services;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPut("{id:guid}")]
        public void Put([FromRoute] Guid id, [FromBody] CreateCategoryDto model)
        {
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleted =  await _categoryService.DeleteCategory(id);
            return Ok(deleted);
        }

        [HttpPost("{id:guid}/SubForums")]
        public void AddSubForum([FromRoute] Guid id, [FromBody] string model)
        {
        }
    }
}
