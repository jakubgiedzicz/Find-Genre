using Find_Genre.Server.Data;
using Find_Genre.Server.Interfaces;
using Find_Genre.Server.Mappers;
using Find_Genre.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Find_Genre.Server.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext context;

        public GenreRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Genre> CreateAsync(CreateGenreDTO genreModel)
        {
            if(genreModel.TagsId == null)
            {
                return null!;
            }
            var genre = genreModel.FromCreateGenreDTO();
            var existing = await context.Genres
                .Where(g => g.Name.ToLower().Contains(genreModel.Name.ToLower()))
                .FirstOrDefaultAsync();
            if (existing != null)
            {
                return null!;
            }
            var tagList = await context.Tags
                .Where(t => genreModel.TagsId.Contains(t.TagId))
                .ToListAsync();
            if (tagList.Count != genreModel.TagsId.Count)
            {
                return null!;
            }
            foreach (var item in tagList)
            {
                genre.Tags?.Add(item);
            }
            if (genreModel.ParentGenresId != null)
            {
                var genreList = await context.Genres
                    .Where(g => genreModel.ParentGenresId.Contains(g.GenreId))
                    .Include(g => g.Subgenres)
                    .ToListAsync();
                foreach (var item in genreList)
                {
                    if (!item.Subgenres!.Contains(genre))
                    {
                        item.Subgenres?.Add(genre);
                    }
                }
            }
            await context.Genres.AddAsync(genre);
            await context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre?> DeleteAsync(int id)
        {
            var genreModel = await context.Genres.FirstOrDefaultAsync(x => x.GenreId == id);

            if (genreModel == null)
            {
                return null;
            }

            context.Genres.Remove(genreModel);
            await context.SaveChangesAsync();

            return genreModel;
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            return await context.Genres
                .Include(g => g.Tags)
                .Include(g => g.Subgenres!)
                .ThenInclude(g => g.Tags)
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await context.Genres
                .Include(g => g.Tags)
                .Include(g => g.Subgenres!)
                .ThenInclude(g => g.Tags)
                .AsSplitQuery()
                .FirstOrDefaultAsync(g => g.GenreId == id);
        }
        public async Task<List<Genre>> GetByTags(List<int> tagIds)
        {
            var genres = await context.Genres
                .Include(t => t.Tags)
                .Include(s => s.Subgenres!)
                .ThenInclude(t => t.Tags)
                .AsSplitQuery()
                .Where(genre => tagIds.All(id => genre.Tags!.Any(Tag => Tag.TagId == id)))
                .ToListAsync();
            return genres;
        }
        public async Task<Genre?> UpdateAsync(int id, CreateGenreDTO genreDTO)
        {
            var existing = await GetByIdAsync(id);
            if (existing == null)
            {
                return null;
            }
            existing.Name = genreDTO.Name;
            existing.Description = genreDTO.Description;
            existing.Promoted = genreDTO.Promoted;
            existing.Examples = genreDTO.Examples;
            var tagList = await context.Tags
                .Where(t => genreDTO.TagsId!.Contains(t.TagId))
                .ToListAsync();
            foreach (var item in tagList!)
            {
                existing.Tags?.Add(tagList.First(t => t.TagId == item.TagId));
            }
            //fix repeating tags
            if (genreDTO.ParentGenresId != null)
            {
                var genreList = await context.Genres
                    .Where(g => genreDTO.ParentGenresId.Contains(g.GenreId))
                    .Include(s => s.Subgenres)
                    .ToListAsync();
                foreach (var item in genreList)
                {
                    item.Subgenres?.Add(existing);
                }
            }
            await context.SaveChangesAsync();
            return existing;
        }
    }
}
