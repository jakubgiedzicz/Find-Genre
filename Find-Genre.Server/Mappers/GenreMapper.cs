using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.DTO.Tag;
using Find_Genre.Server.Models;
using System.Runtime.CompilerServices;

namespace Find_Genre.Server.Mappers
{
    public static class GenreMapper
    {
        public static Genre FromCreateGenreDTO(this CreateGenreDTO createGenreDTO)
        {
            return new Genre
            {
                Name = createGenreDTO.Name,
                Description = createGenreDTO.Description,
                Tags = [],
            };
        }
        public static GenreGetAllDTO FromGenreToGetAllDTO(this Genre genre)
        {
            return new GenreGetAllDTO
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
                Tags = genre.Tags.Select(g => new TagSDTO { Id = g.Id, Name = g.Name }).ToList()
            };
        }
    }
}
