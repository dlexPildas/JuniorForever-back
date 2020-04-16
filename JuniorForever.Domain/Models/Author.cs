using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorForever.Domain.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Post> Posts { get; set; }
    }
}
