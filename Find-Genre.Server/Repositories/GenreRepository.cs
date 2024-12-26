using Find_Genre.Server.Data;
using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.DTO.Tag;
using Find_Genre.Server.Interfaces;
using Find_Genre.Server.Mappers;
using Find_Genre.Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var tagList = await context.Tags.Where(t => genreModel.TagId.Contains(t.Id)).ToListAsync();
            if (tagList.Count != genreModel.TagId.Count)
            {
                return null;
            }
            var existing = await context.Genres.Where(g => g.Name.ToLower().Contains(genreModel.Name.ToLower())).FirstOrDefaultAsync();
            if (existing != null)
            {
                return null;
            }
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
            var genre = await context.Genres.Include(g => g.Tags).FirstAsync(g => g.Id == id);
            if (genre == null)
            {
                return null;
            }
            genre.Popularity += 1;
            await context.SaveChangesAsync();
            return genre;
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
            var tagList = await context.Tags.Where(t => genreDTO.TagId.Contains(t.Id)).ToListAsync();
            if (tagList.Count != genreDTO.TagId.Count)
            {
                return null;
            }
            foreach (var item in genreDTO.TagId)
            {
                existing.Tags.Add(tagList.First(t => t.Id == item));
            }
            await context.SaveChangesAsync();
            return existing;
        }
    }
}
