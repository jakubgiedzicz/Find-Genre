using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.DTO.Tag;
using Find_Genre.Server.Models;

namespace Find_Genre.Server.Mappers
{
    public static class TagMapper
    {
        public static TagDTO ToTagDTO(this Tag tagModel)
        {
            return new TagDTO
            {
                Id = tagModel.Id,
                Name = tagModel.Name,
                Genres = tagModel.Genres.Select(g => new GenreDTO { Id = g.Id, Name = g.Name }).ToList()
            };
        }
    }
}
