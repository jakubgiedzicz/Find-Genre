using Find_Genre.Server.Data;
using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.DTO.Tag;
using Find_Genre.Server.Interfaces;
using Find_Genre.Server.Mappers;
using Find_Genre.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Find_Genre.Server.Controllers
{
    [Route("api/tag")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository tagRepo;

        public TagController(ITagRepository tagRepo)
        {
            this.tagRepo = tagRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await tagRepo.GetAllAsync();
            var tagDTO = tags.Select(s => s.FromTagToTagShallowDTO());

            return Ok(tagDTO);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tag = await tagRepo.GetByIdAsync(id);
            var tagDTO = tag.FromTagToTagShallowDTO();
            if (tagDTO == null)
            {
                return NotFound();
            }
            return Ok(tagDTO);
        }
        [HttpGet("/bytag")]
        public async Task<IActionResult> GetByTags([FromQuery] List<int> tagIds)
        {
            var genres = await tagRepo.GetByTags(tagIds);
            if (genres == null)
            {
                return NotFound();
            }
            return Ok(genres);
        }
        [HttpPost]
        public async Task <IActionResult> Create([FromBody] CreateTagDTO tagDTO)
        {
            var tag = await tagRepo.CreateAsync(tagDTO);
            return CreatedAtAction(nameof(GetById), new { id = tag.Id }, tag.FromTagToTagShallowDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateTagDTO updateDTO)
        {
            var tagModel = await tagRepo.UpdateAsync(id, updateDTO);
            if (tagModel == null)
            {
                return NotFound();
            }
            return Ok(tagModel.FromTagToTagShallowDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tagModel = await tagRepo.DeleteAsync(id);

            if (tagModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
