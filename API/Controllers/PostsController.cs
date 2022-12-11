using Application.DTOs.Category;
using Application.DTOs.Post;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        [Authorize(Roles = "Administrator, Moderator")]
        [ProducesResponseType(typeof(PostResponseDto), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdatePostDto updatePostDto)
        {
            try
            {
                var post = await _postService.UpdatePost(id, updatePostDto);
                return Ok(post);
            }
            catch (ApplicationException) { return NotFound(); }
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Administrator, Moderator")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _postService.DeletePost(id);
                return NoContent();
            }
            catch (ApplicationException) { return NotFound(); }
        }


        [HttpPost("{id:guid}/upvote")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Upvote([FromRoute] Guid id)
        {
            try
            {
                await _postService.UpvotePost(id, HttpContext.User.Identity.Name);
                return Ok();
            }
            catch (ApplicationException e)
            {
                if (e.Message == "NOT FOUND") return NotFound();
                if (e.Message == "BAD REQUEST") return BadRequest();
                else return (IActionResult)e;
            }
        }

        [HttpPost("{id:guid}/downvote")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Downvote([FromRoute] Guid id)
        {
            try
            {
                await _postService.DownvotePost(id, HttpContext.User.Identity.Name);
                return Ok();
            }
            catch (ApplicationException e)
            {
                if (e.Message == "NOT FOUND") return NotFound();
                if (e.Message == "BAD REQUEST") return BadRequest();
                else return (IActionResult)e;
            }
        }
    }
}
