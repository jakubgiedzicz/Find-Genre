using System.ComponentModel.DataAnnotations;

namespace Find_Genre.Server.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public List<Genre>? Genres { get; set; }
    }
}
