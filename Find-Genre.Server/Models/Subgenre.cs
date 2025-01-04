using Find_Genre.Server.DTO.Tag;
using System.ComponentModel.DataAnnotations;

namespace Find_Genre.Server.Models
{
    public class Subgenre
    {
        [Range(1, int.MaxValue)]
        public int SubgenreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Examples { get; set; } = new List<string>();
        public List<string> Promoted { get; set; } = new List<string>();
        public int Popularity { get; set; }
        public List<TagDTO>? Tags { get; set; }
    }
}
