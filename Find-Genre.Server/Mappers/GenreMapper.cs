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
                Tags = new List<Tag>(),
                ParentGenresId = new List<int>(),
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
                Tags = genre.Tags?.Select(t => t.FromTagToTagDTO()).ToList(),
                Examples = genre.Examples,
                Promoted = genre.Promoted,
                Popularity = genre.Popularity
            };
        }
        public static GenreDTO FromGenreToGenreDTO(this Genre genre)
        {
            return new GenreDTO
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
        public static Genre FromGenreShallowToGenre(this GenreShallowTagDTO genre)
        {
            return new Genre
            {
                Description = genre.Description,
                Examples = genre.Examples,
                Id = genre.Id,
                Name = genre.Name,
                Popularity = genre.Popularity,
                Promoted = genre.Promoted,
                Tags = genre.Tags?.Select(t => new Tag { Id = t.Id, Name = t.Name, Genres = [] }).ToList()
            };
        }
    }
}
