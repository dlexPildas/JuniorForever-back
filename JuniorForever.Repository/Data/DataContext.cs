using Microsoft.EntityFrameworkCore;
using JuniorForever.Domain.Models;

namespace JuniorForever.Repository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Author> Authors { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Password=leinad10011;Persist Security Info=True;User ID=dev;Initial Catalog=Junior_Forever_DEV;Data Source=(localdb)\JuniorForever");
        }
    }
}
