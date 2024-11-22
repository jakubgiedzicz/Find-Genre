using Find_Genre.Server.DTO.Tag;
using Find_Genre.Server.Models;

namespace Find_Genre.Server.Mappers
{
    public static class TagMapper
    {
        public static TagDTO ToTagDTO(this Tag tagModel)
        {
            return new TagDTO
            {
                TagId = tagModel.TagId,
                Name = tagModel.Name,
                GenreId = tagModel.GenreId
            };
        }
    }
}
