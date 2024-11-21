namespace Find_Genre.Server.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Tag[] Tags { get; set; }
        public string[] Examples { get; set; }
    }
}
