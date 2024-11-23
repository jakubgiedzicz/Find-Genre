using Find_Genre.Server.Data;
using Find_Genre.Server.Interfaces;
using Find_Genre.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Find_Genre.Server.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext context;

        public TagRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Tag>> GetAllAsync()
        {
            return await context.Tags.Include(t => t.Genres).ToListAsync();
        }
        public async Task<Tag> CreateAsync(Tag tagModel)
        {
            await context.Tags.AddAsync(tagModel);
            await context.SaveChangesAsync();
            return tagModel;
        }
    }
}
