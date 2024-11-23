using System.Text.Json.Serialization;

namespace Find_Genre.Server.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Genre>? Genres { get; set; }
    }
}
