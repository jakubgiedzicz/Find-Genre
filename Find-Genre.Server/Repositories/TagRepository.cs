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
                    TagId = t.TagId,
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
                    TagId = t.TagId,
                    Name = t.Name
                })
                .FirstOrDefaultAsync(g => g.TagId == id);
        }
        public async Task<Tag?> CreateAsync(CreateTagDTO tagModel)
        {
            var tag = tagModel.FromCreateTagDTO();
            var existing = await context.Tags.Where(t => t.Name.ToLower().Contains(tagModel.Name.ToLower())).FirstOrDefaultAsync();
            if (existing != null)
            {
                return null;
            }
            if (tagModel.GenreIds.Count != 0) {
                var genres = await context.Genres.Where(g => tagModel.GenreIds.Contains(g.GenreId)).ToListAsync();
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
        public async Task<TagShallowGenreDTO?> UpdateAsync(int id, CreateTagDTO tagDTO)
        {
            var existing = await context.Tags
                .Include(g => g.Genres)
                .Select(t => new TagShallowGenreDTO
                {
                    TagId = t.TagId,
                    Name = t.Name,
                    Genres = t.Genres.Select(g => g.FromGenreToGenreDTO()).ToList()
                })
                .FirstOrDefaultAsync(x => x.TagId == id);
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
                Where(g => tagDTO.GenreIds.Contains(g.GenreId))
                .AsNoTracking()
                .ToListAsync();

            if (genres.Count != tagDTO.GenreIds.Count)
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
