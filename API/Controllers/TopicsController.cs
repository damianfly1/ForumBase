using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public string Get([FromRoute] Guid id)
        {
            return "value";
        }

        [HttpPut("{id:guid}")]
        public void Put([FromRoute] Guid id, [FromBody] string model)
        {
        }

        [HttpDelete("{id:guid}")]
        public void Delete([FromRoute] Guid id)
        {
        }

        [HttpPost("{id:guid}/Posts")]
        public void AddPost([FromRoute] Guid id, [FromBody] string model)
        {
        }
    }
}
