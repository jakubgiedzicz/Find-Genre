using Find_Genre.Server.Data;
using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.DTO.Tag;
using Find_Genre.Server.Interfaces;
using Find_Genre.Server.Mappers;
using Find_Genre.Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
        public async Task<List<GenreShallowTagDTO>> GetByTags(List<int> tagIds)
        {
            var tags = context.Tags.Where(g => tagIds.Contains(g.Id));
            var genres = context.Genres.Include(g => g.Tags).Where(b => tags.All(genre => b.Tags.Contains(genre)));
            var genreDTO = new List<GenreShallowTagDTO>();
            foreach (var item in genres)
            {
                genreDTO.Add(item.FromGenreToGenreShallowDTO());
            }

            return genreDTO;
        }
        public async Task<Tag> CreateAsync(CreateTagDTO tagModel)
        {
            var tag = tagModel.FromCreateTagDTO();
            var genres = await context.Genres.Where(g => tagModel.GenreId.Contains(g.Id)).ToListAsync();
            if (genres.Count != tagModel.GenreId.Count)
            {
                return null;
            }
            var existing = await context.Tags.Where(t => t.Name.ToLower().Contains(tagModel.Name.ToLower())).FirstOrDefaultAsync();
            if (existing != null)
            {
                return null;
            }
            foreach (var item in genres)
            {
                tag.Genres.Add(item);
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
            var name = await context.Tags.Where(t => t.Name.ToLower().Contains(tagDTO.Name.ToLower())).FirstOrDefaultAsync();
            if (name != null)
            {
                return null;
            }
            var genres = await context.Genres.Where(g => tagDTO.GenreId.Contains(g.Id)).ToListAsync();
            if (genres.Count != tagDTO.GenreId.Count)
            {
                return null;
            }
            existing.Name = tagDTO.Name;
            existing.Genres.Clear();
            foreach (var item in genres)
            {
                existing.Genres.Add(item);
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
