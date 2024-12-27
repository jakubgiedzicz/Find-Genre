using System.ComponentModel.DataAnnotations;

namespace Find_Genre.Server.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public List<Genre>? Genres { get; set; }
    }
}
