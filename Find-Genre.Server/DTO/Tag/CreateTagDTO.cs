namespace Find_Genre.Server.DTO.Tag
{
    public class CreateTagDTO
    {
        public string Name { get; set; } = string.Empty;
        public List<int> GenreId { get; set; } = new List<int>();
    }
}
