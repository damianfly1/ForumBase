using Application.DTOs.Category;
using Application.DTOs.SubForum;
using Application.DTOs.Topic;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubForumsController : ControllerBase
    {
        private readonly ISubForumService _subForumService;
        private readonly ITopicService _topicService;

        public SubForumsController(ISubForumService subForumService, ITopicService topicService)
        {
            _subForumService = subForumService;
            _topicService = topicService;
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(SubForumParentNestedResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var subForumDto = await _subForumService.GetSubForumNested(id);
                return Ok(subForumDto);
            }
            catch (ApplicationException) { return NotFound(); }
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(SubForumResponseDto), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateSubForumDto updateSubForumDto)
        {
            try
            {
                var subForumDto = await _subForumService.UpdateSubForum(id, updateSubForumDto);
                return Ok(subForumDto);
            }
            catch (ApplicationException) { return NotFound(); }
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
                await _subForumService.DeleteSubForum(id);
                return NoContent();
            }
            catch (ApplicationException) { return NotFound(); }
        }

        [HttpPost("{id:guid}/Topics")]
        [Authorize]
        [ProducesResponseType(typeof(TopicResponseDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> AddTopic([FromRoute] Guid id, [FromBody] CreateTopicDto createTopicDto)
        {
            try
            {
                var topicDto = await _topicService.AddTopic(id, createTopicDto, HttpContext.User.Identity.Name);
                return CreatedAtAction(null, topicDto);
            }
            catch (ApplicationException) { return NotFound(); }
        }
    }
}
