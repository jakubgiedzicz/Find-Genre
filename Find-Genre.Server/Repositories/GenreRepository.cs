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
            //genre bez id
            var genre = new CreateGenreDTO
            {
                Name = genreModel.Name,
                Description = genreModel.Description,
                Tags = []
            };
            var tagList = await context.Tags.ToListAsync();
            foreach (var item in genreModel.Tags)
            {
                genre.Tags.Add(tagList.First(t => t.Id == item.Id));
            }
            await context.Genres.AddAsync(genre.FromCreateGenreDTO());
            await context.SaveChangesAsync();
            return genre.FromCreateGenreDTO();
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

        public async Task<Genre?> GetByName(string name)
        {
            return await context.Genres.Include(g => g.Tags).FirstOrDefaultAsync(g => g.Name == name);
        }

        public async Task<Genre?> UpdateAsync(int id, Genre genreDTO)
        {
            var existing = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null)
            {
                return null;
            }
            existing.Name = genreDTO.Name;
            existing.Description = genreDTO.Description;

            await context.SaveChangesAsync();
            return existing;
        }

        public Task<Genre?> UpdateTagsOnGenre(string genred, List<Tag> tags)
        {
            throw new NotImplementedException();
        }
    }
}
