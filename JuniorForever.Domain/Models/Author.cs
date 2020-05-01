using System;
using System.Collections.Generic;
using System.Text;
using JuniorForever.Domain.Enum;

namespace JuniorForever.Domain.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string AvatarUrl { get; set; }
        public AuthorType AuthorType { get; set; }
    }
}
