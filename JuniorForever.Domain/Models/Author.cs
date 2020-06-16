using JuniorForever.Domain.Enum;
using JuniorForever.Domain.Identity;

namespace JuniorForever.Domain.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string AvatarUrl { get; set; }
        public AuthorType AuthorType { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
