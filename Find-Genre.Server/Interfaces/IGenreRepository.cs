using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.DTO.Tag;
using Find_Genre.Server.Models;

namespace Find_Genre.Server.Interfaces
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllAsync();
        Task<Genre?> GetByIdAsync(int id);
        Task<Genre?> GetByName(string name);
        Task<Genre> CreateAsync(CreateGenreDTO genreModel);
        Task<Genre?> UpdateAsync(int id, CreateGenreDTO genre);
        Task<Genre?> DeleteAsync(int id);
    }
}
