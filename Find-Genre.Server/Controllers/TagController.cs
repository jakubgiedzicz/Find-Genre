using Find_Genre.Server.Data;
using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.DTO.Tag;
using Find_Genre.Server.Filters;
using Find_Genre.Server.Interfaces;
using Find_Genre.Server.Mappers;
using Find_Genre.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Find_Genre.Server.Controllers
{
    [Authorize]
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
            var result = new List<TagDTO>();
            foreach (var tag in tags)
            {
                result.Add(tag.FromTagToTagDTO());
            }
            return Ok(result);
        }
        [Tag_ValidateTagIdFilter]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tag = await tagRepo.GetByIdAsync(id);
            if (tag == null)
            {
                ModelState.AddModelError("Tag", "Specified Tag not found");
            }
            return Ok(tag.FromTagToTagShallowDTO());
        }
        [HttpPost]
        public async Task <IActionResult> Create([FromBody] CreateTagDTO tagDTO)
        {
            var tag = await tagRepo.CreateAsync(tagDTO);
            if (tag == null)
            {
                return NotFound();
            };
            return CreatedAtAction(nameof(GetById), new { id = tag.TagId }, tag.FromTagToTagShallowDTO());
        }
        [Tag_ValidateTagIdFilter]
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
        [Tag_ValidateTagIdFilter]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tagModel = await tagRepo.DeleteAsync(id);

            if (tagModel == null)
            {
                ModelState.AddModelError("Tag", "Specified tag not found");
            }

            return NoContent();
        }

    }
}
