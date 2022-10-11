using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpPut("{id:guid}")]
        public void Put([FromRoute] Guid id, [FromBody] string model)
        {
        }

        [HttpDelete("{id:guid}")]
        public void Delete([FromRoute] Guid id)
        {
        }

        [HttpPost("{id:guid}/SubForums")]
        public void AddSubForum([FromRoute] Guid id, [FromBody] string model)
        {
        }
    }
}
