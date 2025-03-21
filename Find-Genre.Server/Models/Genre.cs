﻿using System.ComponentModel.DataAnnotations;

namespace Find_Genre.Server.Models
{
    public class Genre
    {
        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Examples { get; set; } = new List<string>();
        public List<string> Promoted { get; set; } = new List<string>();
        public int Popularity { get; set; }
        public List<Tag>? Tags { get; set; } = new List<Tag>();
        public List<Genre>? ParentGenres { get; set; } = new List<Genre>();
        public List<Genre>? Subgenres { get; set; } = new List<Genre>();
    }
}
