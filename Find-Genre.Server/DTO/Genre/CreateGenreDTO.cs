using Find_Genre.Server.Filters;
using System.ComponentModel.DataAnnotations;

namespace Find_Genre.Server.Models
{
    public class CreateGenreDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Examples { get; set; } = new List<string>();
        public List<string> Promoted { get; set; } = new List<string>();
        [Validate_CreateGenreTagIds]
        public List<int>? TagsId { get; set; } = new List<int>();
        [Validate_CreateGenreTagIds]
        public List<int>? ParentGenresId { get; set; } = new List<int>();
    }
}
