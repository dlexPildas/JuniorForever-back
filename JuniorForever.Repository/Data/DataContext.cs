using Microsoft.EntityFrameworkCore;
using JuniorForever.Domain.Models;

namespace JuniorForever.Repository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Author> Authors { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}
