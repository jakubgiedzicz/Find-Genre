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
            var genreDTO = genres.Select(s => s.ToGenreDTO()).ToList();


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
            return Ok(genre.ToGenreDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGenreRequestDTO genreDTO)
        {
            var genreModel = genreDTO.ToGenreFromCreateDTO();
            await genreRepo.CreateAsync(genreModel);
            return CreatedAtAction(nameof(GetById), new { id = genreModel.GenreId }, genreModel.ToGenreDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGenreRequestDTO updateDTO)
        {
            var genreModel = await genreRepo.UpdateAsync(id, updateDTO);
            if (genreModel == null)
            {
                return NotFound();
            }
            

            return Ok(genreModel.ToGenreDTO());
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
