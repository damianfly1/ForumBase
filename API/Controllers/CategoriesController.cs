using API.Models;
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
        public void Put([FromRoute] Guid id, [FromBody] CategoryCreateRequestModel model)
        {
        }

        [HttpDelete("{id:guid}")]
        public async Task<Category> Delete([FromRoute] Guid id)
        {
            var deleted =  await _categoryService.DeleteCategory(id);
            return deleted;
        }

        [HttpPost("{id:guid}/SubForums")]
        public void AddSubForum([FromRoute] Guid id, [FromBody] SubForumModel model)
        {
        }
    }
}
