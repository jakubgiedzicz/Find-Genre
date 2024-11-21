using Find_Genre.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace Find_Genre.Server.Controllers
{
    [ApiController]
    [Route("/api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GenreController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = context.Genres.ToList();
            

            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var genre = context.Genres.Find(id);

            if(genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }
    }
}
