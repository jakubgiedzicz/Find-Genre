using Find_Genre.Server.DTO.Tag;

namespace Find_Genre.Server.DTO.Genre
{
    public class GenreShallowTagDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Examples { get; set; } = new List<string>();
        public List<string> Promoted { get; set; } = new List<string>();
        public List<TagDTO>? Tags { get; set; }
    }
}
