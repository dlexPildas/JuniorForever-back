using JuniorForever.Domain.Identity;
using JuniorForever.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace JuniorForever.Repository.Data
{
    public class DataContext : IdentityDbContext<
        User, Role, int, IdentityUserClaim<int>,
        UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<Post>()
                .HasOne(x => x.Author)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<Rating>()
                .HasOne(x => x.Author)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Password=leinad10011;Persist Security Info=True;User ID=dev;Initial Catalog=Junior_Forever_Development;Data Source=(localdb)\JuniorForever");
        }
    }
}
