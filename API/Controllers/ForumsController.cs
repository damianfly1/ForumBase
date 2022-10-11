using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumsController : ControllerBase
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

        [HttpPost("{id:guid}/Categories")]
        public void AddCategory([FromRoute] Guid id, [FromBody] string model)
        {
        }

    }
}
