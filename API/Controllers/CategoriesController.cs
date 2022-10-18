using Application.DTOs;
using Application.DTOs.Category;
using Application.DTOs.SubForum;
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
        private readonly ISubForumService _subForumService;

        public CategoriesController(ICategoryService categoryService, ISubForumService subForumService)
        {
            _categoryService = categoryService;
            _subForumService = subForumService;
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var categoryDto = await _categoryService.UpdateCategory(id, updateCategoryDto);
            return Ok(categoryDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleted =  await _categoryService.DeleteCategory(id);
            return Ok(deleted);
        }

        [HttpPost("{id:guid}/SubForums")]
        public async Task<IActionResult> AddSubForum([FromRoute] Guid id, [FromBody] CreateSubForumDto createSubForumDto)
        {
            var subForumDto = await _subForumService.AddSubForum(id, createSubForumDto);
            return Ok(subForumDto);
        }
    }
}
