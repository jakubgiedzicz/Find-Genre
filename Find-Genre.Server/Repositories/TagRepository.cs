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
        public async Task<List<TagDTO>> GetAllAsync()
        {
            return await context.Tags
                .Include(t => t.Genres)
                .Select(t => new TagDTO
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }
        public async Task<TagDTO> GetByIdAsync(int id)
        {
            return await context.Tags
                .Include(g => g.Genres)
                .Select(t => new TagDTO
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task<Tag?> CreateAsync(CreateTagDTO tagModel)
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
        public async Task<TagShallowGenreDTO?> UpdateAsync(int id, CreateTagDTO tagDTO)
        {
            var existing = await context.Tags
                .Include(g => g.Genres)
                .Select(t => new TagShallowGenreDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                    Genres = t.Genres.Select(g => g.FromGenreToGenreDTO()).ToList()
                })
                .FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null)
            {
                return null;
            }
            var name = await context.Tags
                .Where(t => t.Name.ToLower()
                .Contains(tagDTO.Name.ToLower()))
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (name != null)
            {
                return null;
            }
            var genres = await context.Genres.
                Where(g => tagDTO.GenreId.Contains(g.Id))
                .AsNoTracking()
                .ToListAsync();

            if (genres.Count != tagDTO.GenreId.Count)
            {
                return null;
            }
            existing.Name = tagDTO.Name;
            existing.Genres.Clear();
            foreach (var item in genres)
            {
                existing.Genres.Add(item.FromGenreToGenreDTO());
            }
            context.Tags.Entry(existing.FromTagShallowToTag()).CurrentValues.SetValues(existing.FromTagShallowToTag());
            context.Tags.Entry(existing.FromTagShallowToTag()).State = EntityState.Modified;
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
