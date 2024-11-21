namespace Find_Genre.Server.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
