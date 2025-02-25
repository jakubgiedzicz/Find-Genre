using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.DTO.Tag;
using Find_Genre.Server.Models;

namespace Find_Genre.Server.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetAllAsync();
        Task<Tag?> GetByIdAsync(int id);
        Task<Tag?> CreateAsync(CreateTagDTO tagModel);
        Task<Tag?> UpdateAsync(int id, CreateTagDTO tag);
        Task<Tag?> DeleteAsync(int id);
    }
}
