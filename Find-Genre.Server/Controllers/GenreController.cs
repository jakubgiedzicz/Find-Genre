using Find_Genre.Server.Data;
using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.Interfaces;
using Find_Genre.Server.Mappers;
using Find_Genre.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Find_Genre.Server.Controllers
{
    [ApiController]
    [Route("/api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository genreRepo;

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
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var genre = await genreRepo.GetByIdAsync(id);

            if(genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGenreDTO genreDTO)
        {
            await genreRepo.CreateAsync(genreDTO);
            //return CreatedAtAction(nameof(GetById), new { id = genreDTO.Id }, genreModel.ToGenreDTO());
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateGenreDTO updateDTO)
        {
            //var genreModel = await genreRepo.UpdateAsync(id, updateDTO);
            //if (genreModel == null)
            //{
              //  return NotFound();
            //}
            throw new NotImplementedException();
            
//            return Ok(genreModel.ToGenreDTO());
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
