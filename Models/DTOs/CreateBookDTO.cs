﻿namespace Labb_LibraryApi.Models.DTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
    }
}
