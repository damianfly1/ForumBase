using Application.DTOs.Post;
using Application.DTOs.Topic;
using Application.Services;
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
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var topic = _topicService.GetTopicNested(id);
            return Ok(topic);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateTopicDto updateTopicDto)
        {
            var topic = await _topicService.UpdateTopic(id, updateTopicDto);
            return Ok(topic);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var topic = await _topicService.DeleteTopic(id);
            return Ok(topic);
        }

        [HttpPost("{id:guid}/Posts")]
        public async Task<IActionResult> AddPost([FromRoute] Guid id, [FromBody] CreatePostDto createPostDto)
        {
            var post = await _postService.AddPost(id, createPostDto);
            return Ok(post);
        }
    }
}
