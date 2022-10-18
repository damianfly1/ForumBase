using Application.DTOs.SubForum;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubForumsController : ControllerBase
    {
        private readonly ISubForumService _subForumService;

        public SubForumsController(ISubForumService subForumService)
        {
            _subForumService = subForumService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var subForumDto = await _subForumService.GetSubForumNested(id);
            return Ok(subForumDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateSubForumDto updateSubForumDto)
        {
            var subForumDto = await _subForumService.UpdateSubForum(id, updateSubForumDto);
            return Ok(subForumDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var subForumDto = await _subForumService.DeleteSubForum(id);
            return Ok(subForumDto);
        }

        [HttpPost("{id:guid}/Topics")]
        public void AddTopic([FromRoute] Guid id, [FromBody] string model)
        {
        }
    }
}
