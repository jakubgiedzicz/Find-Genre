using Find_Genre.Server.Data;
using Find_Genre.Server.Interfaces;
using Find_Genre.Server.Mappers;
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
    }
}
