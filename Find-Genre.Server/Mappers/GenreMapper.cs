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
                Examples = createGenreDTO.Examples,
                Promoted = createGenreDTO.Promoted,
                Popularity = 0
            };
        }
        public static GenreShallowTagDTO FromGenreToGenreShallowDTO(this Genre genre)
        {
            return new GenreShallowTagDTO
            {
                GenreId = genre.GenreId,
                Name = genre.Name,
                Description = genre.Description,
                Tags = genre.Tags?.Select(t => t.FromTagToTagDTO()).ToList(),
                Examples = genre.Examples,
                Promoted = genre.Promoted,
                Popularity = genre.Popularity,
                Subgenres = genre.Subgenres?.Select(t => t.FromGenreToSubgenre()).ToList()
            };
        }
        public static GenreDTO FromGenreToGenreDTO(this Genre genre)
        {
            return new GenreDTO
            {
                GenreId = genre.GenreId,
                Name = genre.Name
            };
        }
        public static Subgenre FromGenreToSubgenre(this Genre subgenre)
        {
            return new Subgenre
            {
                Description = subgenre.Description,
                Examples = subgenre.Examples,
                SubgenreId = subgenre.GenreId,
                Name = subgenre.Name,
                Popularity = subgenre.Popularity,
                Promoted = subgenre.Promoted,
                Tags = subgenre?.Tags?.Select(t => t.FromTagToTagDTO()).ToList()
            };
        }
    }
}
