using Application.DTOs.Category;
using Application.DTOs.Forum;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ForumsController : ControllerBase
{
    private readonly IForumService _forumService;
    private readonly ICategoryService _categoryService;

    public ForumsController(IForumService forumService, ICategoryService categoryService)
    {
        _forumService = forumService;
        _categoryService = categoryService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ForumNestedResponseDto), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var forumDto = await _forumService.GetForumNested();
            return Ok(forumDto);
        }
        catch (ApplicationException) { return NotFound(); }
    }

    [HttpPost("{id:guid}/Categories")]
    [Authorize(Roles ="Administrator")]
    [ProducesResponseType(typeof(CategoryResponseDto), 201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public async Task<IActionResult> AddCategory([FromRoute] Guid id, [FromBody] CreateCategoryDto createCategoryDto)
    {
        try
        {
            var categoryDto = await _categoryService.AddCategory(id, createCategoryDto);
            return CreatedAtAction(null, categoryDto);
        }
        catch (ApplicationException) { return NotFound(); }
    }

}
