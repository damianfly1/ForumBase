using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpPut("{id:guid}")]
        public void Put([FromRoute] Guid id, [FromBody] PostModel model)
        {
        }

        [HttpDelete("{id:guid}")]
        public void Delete([FromRoute] Guid id)
        {
        }
    }
}
