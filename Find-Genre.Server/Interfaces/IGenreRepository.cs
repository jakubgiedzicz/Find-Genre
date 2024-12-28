using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.DTO.Tag;
using Find_Genre.Server.Models;

namespace Find_Genre.Server.Interfaces
{
    public interface IGenreRepository
    {
        Task<bool> GenreExists(int id);
        Task<List<GenreShallowTagDTO>> GetAllAsync();
        Task<GenreShallowTagDTO?> GetByIdAsync(int id);
        Task<List<GenreShallowTagDTO>> GetByTags(List<int> tags);
        Task<Genre> CreateAsync(CreateGenreDTO genreModel);
        Task<Genre?> UpdateAsync(int id, CreateGenreDTO genre);
        Task<Genre?> DeleteAsync(int id);
    }
}
