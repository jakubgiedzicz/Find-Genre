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
                Examples = createGenreDTO.Examples,
                Promoted = createGenreDTO.Promoted,
                Popularity = 0
            };
        }
        public static GenreShallowTagDTO FromGenreToGenreShallowDTO(this Genre genre)
        {
            return new GenreShallowTagDTO
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
                Tags = genre.Tags.Select(g => new TagDTO { Id = g.Id, Name = g.Name }).ToList(),
                Examples = genre.Examples,
                Promoted = genre.Promoted,
                Popularity = genre.Popularity
            };
        }
    }
}
