namespace Find_Genre.Server.DTO.Tag
{
    public class CreateTagDTO
    {
        public string Name { get; set; }
        public List<int>? GenreId { get; set; }
    }
}
