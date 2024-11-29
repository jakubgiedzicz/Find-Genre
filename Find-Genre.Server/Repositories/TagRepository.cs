using Find_Genre.Server.Data;
using Find_Genre.Server.DTO.Genre;
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
            return await context.Tags.Include(t => t.Genres).ToListAsync();
        }
        public async Task<Tag> GetByIdAsync(int id)
        {
            return await context.Tags.Include(g => g.Genres).FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task<Tag> CreateAsync(CreateTagDTO tagModel)
        {
            var tag = tagModel.FromCreateTagDTO();
            var genreList = await context.Genres.ToListAsync();
            foreach (var item in tagModel.GenreId)
            {
                tag.Genres.Add(genreList.First(t => t.Id == item));
            }
            await context.Tags.AddAsync(tag);
            await context.SaveChangesAsync();
            return tag;
        }
        public async Task<Tag?> UpdateAsync(int id, CreateTagDTO tagDTO)
        {
            var existing = await context.Tags.Include(g => g.Genres).FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null)
            {
                return null;
            }
            existing.Name = tagDTO.Name;
            existing.Genres.Clear();
            var genreList = await context.Genres.ToListAsync();
            foreach (var item in tagDTO.GenreId)
            {
                existing.Genres.Add(genreList.First(t => t.Id == item));
            }
            await context.SaveChangesAsync();
            return existing;
        }

        public async Task<Tag?> DeleteAsync(int id)
        {
            var tagModel = await context.Tags.FirstOrDefaultAsync(x => x.Id == id);
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
