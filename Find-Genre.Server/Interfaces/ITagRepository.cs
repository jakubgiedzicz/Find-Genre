using Find_Genre.Server.Models;

namespace Find_Genre.Server.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetAllAsync();
    }
}
