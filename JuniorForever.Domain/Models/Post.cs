using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace JuniorForever.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Stars { get; set; }
        public DateTime Date { get; set; }
        public Author Author { get; set; }
    }
}
