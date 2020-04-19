using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorForever.Domain.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Stars { get; set; }
        public Post Post { get; set; }
        public Author Author { get; set; }
    }
}
