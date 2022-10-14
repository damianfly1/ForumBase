using API.Models;
using Application.DTOs;
using Application.Services;
using AutoMapper;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ForumsController : ControllerBase
{
    private readonly IForumService _forumService;
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public ForumsController(IForumService forumService, IMapper mapper, ICategoryService categoryService)
    {
        _forumService = forumService;
        _mapper = mapper;
        _categoryService = categoryService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var forumModel= await _forumService.GetForumNested(id);
        return Ok(forumModel);
    }

    [HttpPut("{id:guid}")]
    public void Put([FromRoute] Guid id, [FromBody] ForumModel model)
    {
    }

    [HttpPost("{id:guid}/Categories")]
    public async Task<IActionResult> AddCategory([FromRoute] Guid id, [FromBody] CreateCategoryDto model)
    {
        var category = await _categoryService.CreateCategory(id, model);
        return Ok(category);
    }

}
