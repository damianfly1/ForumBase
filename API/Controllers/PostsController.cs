using Application.DTOs.Post;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdatePostDto updatePostDto)
        {
            var post = await _postService.UpdatePost(id, updatePostDto);
            return Ok(post);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var post = await _postService.DeletePost(id);
            return Ok(post);
        }
    }
}
