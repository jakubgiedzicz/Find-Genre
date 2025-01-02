using Find_Genre.Server.Data;
using Find_Genre.Server.Interfaces;
using Find_Genre.Server.Mappers;
using Find_Genre.Server.Models;
using Find_Genre.Server.Filters;
using Microsoft.AspNetCore.Mvc;
using Find_Genre.Server.DTO.Genre;

namespace Find_Genre.Server.Controllers
{
    [ApiController]
    [Route("/api/genre")]
    public class GenreController : ControllerBase
    {
        public readonly IGenreRepository genreRepo;

        public GenreController(ApplicationDbContext context, IGenreRepository genreRepo)
        {
            this.genreRepo = genreRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await genreRepo.GetAllAsync();

            return Ok(genres);
        }
        [HttpGet("{id:int}")]
        [Genre_ValidateGenreIdFilter]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var genre = await genreRepo.GetByIdAsync(id);
            if (genre == null)
            {
                ModelState.AddModelError("Genre", "Specified genre not found");

            }
            return Ok(genre);            
        }

        [HttpGet("/bytag")]
        public async Task<IActionResult> GetByTags([FromQuery] List<int> tag)
        {
            var genres = await genreRepo.GetByTags(tag);
            if (genres == null)
            {
                return NotFound();
            }
            return Ok(genres);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGenreDTO genreDTO)
        {
            var genre = await genreRepo.CreateAsync(genreDTO);
            if(genre == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetById), new { id = genre.Id }, genre.FromGenreToGenreShallowDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateGenreDTO updateDTO)
        {
            var genreModel = await genreRepo.UpdateAsync(id, updateDTO);
            if (genreModel == null)
            {
              return NotFound();
            }
            return Ok(genreModel);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var genreModel = await genreRepo.DeleteAsync(id);

            if (genreModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
