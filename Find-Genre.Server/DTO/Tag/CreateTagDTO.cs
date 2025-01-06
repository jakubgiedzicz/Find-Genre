using Find_Genre.Server.Filters;

namespace Find_Genre.Server.DTO.Tag
{
    public class CreateTagDTO
    {
        public string Name { get; set; } = string.Empty;
        [Tag_CreateTagGenreIds]
        public List<int> GenreIds { get; set; } = new List<int>();
    }
}
