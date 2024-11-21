using Find_Genre.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace Find_Genre.Server.Controllers
{
    [Route("api/tag")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TagController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var tags = context.Tags.ToList();

            return Ok(tags);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {

            var tag = context.Tags.Find(id);

            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }
    }
}
