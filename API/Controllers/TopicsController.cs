using Application.DTOs.Post;
using Application.DTOs.Topic;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private readonly IPostService _postService;

        public TopicsController(ITopicService topicService, IPostService postService)
        {
            _topicService = topicService;
            _postService = postService;
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TopicParentNestedResponseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var topic = await _topicService.GetTopicNested(id);
                return Ok(topic);
            }
            catch (ApplicationException) { return NotFound(); }
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Administrator, Moderator")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateTopicDto updateTopicDto)
        {
            try
            {
                var topic = await _topicService.UpdateTopic(id, updateTopicDto);
                return Ok(topic);
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
                await _topicService.DeleteTopic(id);
                return NoContent();
            }
            catch (ApplicationException) { return NotFound(); }
        }

        [HttpPost("{id:guid}/Posts")]
        [Authorize]
        [ProducesResponseType(typeof(PostResponseDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> AddPost([FromRoute] Guid id, [FromBody] CreatePostDto createPostDto)
        {
            try
            {
                var post = await _postService.AddPost(id, createPostDto, HttpContext.User.Identity.Name);
                return CreatedAtAction(null, post);
            }
            catch (ApplicationException) { return NotFound(); }
        }
    }
}
