using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubForumsController : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public string Get([FromRoute] Guid id)
        {
            return "value";
        }

        [HttpPut("{id:guid}")]
        public void Put([FromRoute] Guid id, [FromBody] SubForumModel model)
        {
        }

        [HttpDelete("{id:guid}")]
        public void Delete([FromRoute] Guid id)
        {
        }

        [HttpPost("{id:guid}/Topics")]
        public void AddTopic([FromRoute] Guid id, [FromBody] TopicModel model)
        {
        }
    }
}
