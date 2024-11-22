using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.Models;

namespace Find_Genre.Server.Interfaces
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllAsync();
        Task<Genre?> GetByIdAsync(int id);
        Task<Genre> CreateAsync(Genre genreModel);
        Task<Genre?> UpdateAsync(int id, UpdateGenreRequestDTO genreDTO);
        Task<Genre?> DeleteAsync(int id);
    }
}
