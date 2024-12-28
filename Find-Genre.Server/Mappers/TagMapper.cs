using Find_Genre.Server.DTO.Genre;
using Find_Genre.Server.DTO.Tag;
using Find_Genre.Server.Models;
using System.Runtime.CompilerServices;

namespace Find_Genre.Server.Mappers
{
    public static class TagMapper
    {
        public static TagShallowGenreDTO FromTagToTagShallowDTO(this Tag tagModel)
        {
            return new TagShallowGenreDTO
            {
                Id = tagModel.Id,
                Name = tagModel.Name,
                Genres = tagModel.Genres?.Select(g => new GenreDTO { Id = g.Id, Name = g.Name }).ToList()
            };
        }
        public static Tag FromTagShallowToTag(this TagShallowGenreDTO tagModel)
        {
            return new Tag
            {
                Id = tagModel.Id,
                Name = tagModel.Name,
                Genres = tagModel.Genres?.Select(g => new Genre { Id = g.Id, Name = g.Name }).ToList()
            };
        }
        public static Tag FromCreateTagDTO(this CreateTagDTO createTagDTO)
        {
            return new Tag
            {
                Name = createTagDTO.Name,
                Genres = []
            };
        }
        public static TagDTO FromTagToTagDTO(this Tag tag)
        {
            return new TagDTO
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }
    }
}
