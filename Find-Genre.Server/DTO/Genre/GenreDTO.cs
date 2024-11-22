using Find_Genre.Server.Models;

namespace Find_Genre.Server.DTO.Genre
{
    public class GenreDTO
    {
        public int GenreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
