using Find_Genre.Server.DTO.Tag;

namespace Find_Genre.Server.DTO.Genre
{
    public class GenreShallowTagDTO : GenreShallowNoTagDTO
    {
        public List<TagDTO>? Tags { get; set; }
    }
}
