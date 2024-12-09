using Find_Genre.Server.DTO.Tag;
namespace Find_Genre.Server.Models
{
    public class CreateGenreDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<int>? TagId { get; set; }
        public List<string> Examples { get; set; } = new List<string>();
        public List<string> Promoted { get; set; } = new List<string>();
    }
}
