using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.Models;
using System.Runtime.CompilerServices;

namespace Find_Genre.Server.Mappers
{
    public static class GenreMapper
    {
        public static GenreDTO ToGenreDTO(this Genre genreModel)
        {
            return new GenreDTO
            {
                Id = genreModel.Id,
                Name = genreModel.Name,
                Description = genreModel.Description,
            };
        }
        public static Genre ToCreateGenreDTO(this CreateGenreDTO createGenreDTO)
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
