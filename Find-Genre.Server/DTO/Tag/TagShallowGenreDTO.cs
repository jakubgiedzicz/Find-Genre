using Find_Genre.Server.DTO.Genre;

namespace Find_Genre.Server.DTO.Tag
{
    public class TagShallowGenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<GenreDTO> Genres { get; set; }
    }
}
