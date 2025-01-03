using Azure;
using Find_Genre.Server.Data;
using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.DTO.Tag;
using Find_Genre.Server.Interfaces;
using Find_Genre.Server.Mappers;
using Find_Genre.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
                return null;
            }
            var genre = genreModel.FromCreateGenreDTO();
            var existing = await context.Genres
                .Where(g => g.Name.ToLower().Contains(genreModel.Name.ToLower()))
                .FirstOrDefaultAsync();
            if (existing != null)
            {
                return null;
            }
            var tagList = await context.Tags
                .Where(t => genreModel.TagsId.Contains(t.TagId))
                .ToListAsync();
            if (tagList.Count != genreModel.TagsId.Count)
            {
                return null;
            }
            foreach (var item in tagList)
            {
                genre.Tags?.Add(item);
            }
            if (genreModel.ParentGenresId != null)
            {
                var genreList = await context.Genres
                    .Where(g => genreModel.ParentGenresId.Contains(g.GenreId))
                    .ToListAsync();
                foreach (var item in genreList)
                {
                    item.Subgenres?.Add(genre);
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

        public async Task<List<GenreShallowTagDTO>> GetAllAsync()
        {
            return await context.Genres
                .Include(g => g.Tags)
                .Include(g => g.Subgenres)
                .AsSplitQuery()
                .Select(g => new GenreShallowTagDTO
                {
                    Tags = g.Tags.Select(t => t.FromTagToTagDTO()).ToList(),
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Description = g.Description,
                    Examples = g.Examples,
                    Popularity = g.Popularity,
                    Promoted = g.Promoted,
                    Subgenres = g.Subgenres.Select(g => g.FromGenreToSubgenre()).ToList()
                })
                .ToListAsync();
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            var genre = await context.Genres
                .Include(g => g.Tags)
                .Include(g => g.Subgenres)
                .AsSplitQuery()
                .FirstOrDefaultAsync(g => g.GenreId == id);
            return genre;
        }
        public async Task<List<GenreShallowTagDTO>> GetByTags(List<int> tagIds)
        {
            var genres = await context.Genres
                .Include(t => t.Tags)
                .Include(s => s.Subgenres)
                .AsSplitQuery()
                .Where(genre => tagIds.All(id => genre.Tags.Any(Tag => Tag.TagId == id)))
                .Select(g => new GenreShallowTagDTO
                {
                    Tags = g.Tags.Select(t => t.FromTagToTagDTO()).ToList(),
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Description = g.Description,
                    Examples = g.Examples,
                    Popularity = g.Popularity,
                    Promoted = g.Promoted,
                    Subgenres = g.Subgenres.Select(s => s.FromGenreToSubgenre()).ToList()
                })
                .ToListAsync();
            var genreDTO = new List<GenreShallowTagDTO>();
            foreach (var item in genres)
            {
                genreDTO.Add(item);
            }
            return genreDTO;
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
            var tagListIds = genreDTO.TagsId.ToList();
            foreach (var tag in existing.Tags.ToList())
            {
                if (genreDTO.TagsId.Contains(tag.TagId))
                {
                    existing.Tags.Remove(tag);
                }
                tagListIds.RemoveAll(r => r == tag.TagId);
            }
            existing.Promoted = genreDTO.Promoted;
            existing.Examples = genreDTO.Examples;
            
            var tagList = await context.Tags
                .Where(t => tagListIds.Contains(t.TagId))
                .ToListAsync();
            foreach (var item in tagListIds)
            {
                existing.Tags.Add(tagList.First(t => t.TagId == item));
            }
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
