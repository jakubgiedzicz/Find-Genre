using Find_Genre.Server.Data;
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
            var tagDTO = tags.Select(s => s.ToTagDTO());

            return Ok(tagDTO);
        }
        [HttpPost]
        public async Task <IActionResult> Create([FromBody] Tag tagDTO)
        {
            var tagModel = tagDTO.ToTagDTO();
            await tagRepo.CreateAsync(tagDTO);
            return Ok("Ok");

        }
    }
}
