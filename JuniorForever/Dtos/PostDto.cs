using System;
using System.Collections.Generic;

namespace JuniorForever.Api.Dtos
{
    public class PostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Theme { get; set; }
        public AuthorDto Author { get; set; }
        public List<RatingDto> Ratings { get; set; }
    }
}
