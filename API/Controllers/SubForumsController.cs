using Application.DTOs.Category;
using Application.DTOs.SubForum;
using Application.DTOs.Topic;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubForumsController : ControllerBase
    {
        private readonly ISubForumService _subForumService;
        private readonly ITopicService _topicService;
        private readonly IPostService _postService;

        public SubForumsController(ISubForumService subForumService, ITopicService topicService, IPostService postService)
        {
            _subForumService = subForumService;
            _topicService = topicService;
            _postService = postService;
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(SubForumParentNestedResponseDto), 200)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var subForumDto = await _subForumService.GetSubForumNested(id);
            return Ok(subForumDto);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(SubForumResponseDto), 200)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateSubForumDto updateSubForumDto)
        {
            var subForumDto = await _subForumService.UpdateSubForum(id, updateSubForumDto);
            return Ok(subForumDto);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(SubForumResponseDto), 200)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var subForumDto = await _subForumService.DeleteSubForum(id);
            return Ok(subForumDto);
        }

        [HttpPost("{id:guid}/Topics")]
        [ProducesResponseType(typeof(TopicResponseDto), 200)]
        public async Task<IActionResult> AddTopic([FromRoute] Guid id, [FromBody] CreateTopicDto createTopicDto)
        {
            var topicDto = await _topicService.AddTopic(id, createTopicDto);
            return Ok(topicDto);
        }
    }
}
