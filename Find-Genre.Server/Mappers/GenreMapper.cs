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
        public static Genre ToGenreFromCreateDTO(this CreateGenreRequestDTO genreDTO)
        {
            return new Genre
            {
                Name = genreDTO.Name,
                Description = genreDTO.Description,
            };
        }
    }
}
