using System;
using System.Collections.Generic;

namespace JuniorForever.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Theme { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
