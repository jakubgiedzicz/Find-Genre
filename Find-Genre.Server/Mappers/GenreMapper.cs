using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.Models;
using System.Runtime.CompilerServices;

namespace Find_Genre.Server.Mappers
{
    public static class GenreMapper
    {
        public static Genre ToGenreDTO(this Genre genreModel)
        {
            return new Genre
            {
                Id = genreModel.Id,
                Name = genreModel.Name,
                Description = genreModel.Description,
            };
        }
        public static Genre FromCreateGenreDTO(this CreateGenreDTO createGenreDTO)
        {
            return new Genre
            {
                Name = createGenreDTO.Name,
                Description = createGenreDTO.Description,
                Tags = createGenreDTO.Tags,
            };
        }
    }
}
