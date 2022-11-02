using Application.DTOs.Category;
using Application.DTOs.Forum;
using Application.Services;
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

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ForumNestedResponseDto), 200)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var forumDto = await _forumService.GetForumNested(id);
        return Ok(forumDto);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateForumDto updateForumDto)
    {
        var forumDto = await _forumService.UpdateForum(id, updateForumDto);
        return Ok(forumDto);
    }

    [HttpPost("{id:guid}/Categories")]
    public async Task<IActionResult> AddCategory([FromRoute] Guid id, [FromBody] CreateCategoryDto createCategoryDto)
    {
        var categoryDto = await _categoryService.AddCategory(id, createCategoryDto);
        return Ok(categoryDto);
    }

}
