using Application.DTOs;
using Application.DTOs.Category;
using Application.DTOs.SubForum;
using Application.Services;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(CategoryResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                var categoryDto = await _categoryService.UpdateCategory(id, updateCategoryDto);
                return Ok(categoryDto);
            }
            catch (ApplicationException){ return NotFound(); }            
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _categoryService.DeleteCategory(id);
                return NoContent();
            }
            catch (ApplicationException) { return NotFound(); }
        }

        [HttpPost("{id:guid}/SubForums")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(SubForumResponseDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> AddSubForum([FromRoute] Guid id, [FromBody] CreateSubForumDto createSubForumDto)
        {
            try
            {
                var subForumDto = await _subForumService.AddSubForum(id, createSubForumDto);
                return CreatedAtAction(null, subForumDto);
            }
            catch (ApplicationException) { return NotFound(); }
        }
    }
}
