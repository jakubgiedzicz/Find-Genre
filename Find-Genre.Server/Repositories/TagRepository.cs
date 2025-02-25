using Find_Genre.Server.Data;
using Find_Genre.Server.DTO.Tag;
using Find_Genre.Server.Interfaces;
using Find_Genre.Server.Mappers;
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
            return await context.Tags
                .ToListAsync();
        }
        public async Task<Tag?> GetByIdAsync(int id)
        {
            return await context.Tags
                .Include(g => g.Genres)
                .FirstOrDefaultAsync(g => g.TagId == id);
        }
        public async Task<Tag?> CreateAsync(CreateTagDTO tagModel)
        {
            var tag = tagModel.FromCreateTagDTO();
            var existing = await context.Tags
                .Where(t => t.Name.ToLower().Contains(tagModel.Name.ToLower()))
                .FirstOrDefaultAsync();
            if (existing != null)
            {
                return null;
            }
            if (tagModel.GenreIds.Count != 0) {
                var genres = await context.Genres
                    .Where(g => tagModel.GenreIds.Contains(g.GenreId))
                    .ToListAsync();
                if (genres.Count != tagModel.GenreIds.Count)
                {
                    return null;
                }
                foreach (var item in genres)
                {
                    tag.Genres?.Add(item);
                }
            }
            await context.Tags.AddAsync(tag);
            await context.SaveChangesAsync();
            return tag;
        }
        public async Task<Tag?> UpdateAsync(int id, CreateTagDTO tagDTO)
        {
            var existing = await GetByIdAsync(id);
            if (existing == null)
            {
                return null;
            }
            existing.Name = tagDTO.Name;
            var genres = await context.Genres.
                Where(g => tagDTO.GenreIds.Contains(g.GenreId))
                .ToListAsync();
            foreach (var item in genres)
            {
                existing.Genres?.Add(item);
            }
            await context.SaveChangesAsync();
            return existing;
        }

        public async Task<Tag?> DeleteAsync(int id)
        {
            var tagModel = await context.Tags.FirstOrDefaultAsync(x => x.TagId == id);
            if (tagModel == null)
            {
                return null;
            }
            context.Tags.Remove(tagModel);
            await context.SaveChangesAsync();
            return tagModel;
        }
    }
}
