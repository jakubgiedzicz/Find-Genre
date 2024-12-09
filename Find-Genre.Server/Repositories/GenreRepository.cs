using Find_Genre.Server.Data;
using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.DTO.Tag;
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
            var genre = genreModel.FromCreateGenreDTO();
            var tagList = context.Tags.Where(t => genreModel.TagId.Contains(t.Id));
            foreach (var item in tagList)
            {
                genre.Tags.Add(item);
            }
            await context.Genres.AddAsync(genre);
            await context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre?> DeleteAsync(int id)
        {
            var genreModel = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
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
            return await context.Genres.Include(g => g.Tags).ToListAsync();
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await context.Genres.Include(g => g.Tags).FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task<Genre?> UpdateAsync(int id, CreateGenreDTO genreDTO)
        {
            var existing = await context.Genres.Include(g => g.Tags).FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null)
            {
                return null;
            }
            existing.Name = genreDTO.Name;
            existing.Description = genreDTO.Description;
            existing.Tags.Clear();
            existing.Promoted = genreDTO.Promoted;
            existing.Examples = genreDTO.Examples;
            var tagList = await context.Tags.ToListAsync();
            foreach (var item in genreDTO.TagId)
            {
                existing.Tags.Add(tagList.First(t => t.Id == item));
            }
            await context.SaveChangesAsync();
            return existing;
        }
    }
}
