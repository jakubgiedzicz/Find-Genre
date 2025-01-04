using System.ComponentModel.DataAnnotations;

namespace Find_Genre.Server.Models
{
    public class Tag
    {
        [Range(1, int.MaxValue)]
        public int TagId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public List<Genre>? Genres { get; set; } = new List<Genre>();
    }
}
