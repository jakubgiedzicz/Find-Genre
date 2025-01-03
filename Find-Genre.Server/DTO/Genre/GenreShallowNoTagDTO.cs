using Find_Genre.Server.Models;

namespace Find_Genre.Server.DTO.Genre
{
    public class GenreShallowNoTagDTO
    {
        public int GenreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Examples { get; set; } = new List<string>();
        public List<string> Promoted { get; set; } = new List<string>();
        public int Popularity { get; set; }
        public List<Subgenre>? Subgenres { get; set; }
    }
}
