using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PopCornAndCritics.Model;

namespace PopCornAndCritics.Data
{
    public class UserContext : DbContext
    {
        
        public UserContext(DbContextOptions<UserContext> opts)
            : base(opts)
        {
            
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           var result = modelBuilder.Entity<User>()
                .HasIndex(u => new { u.email })
                .IsUnique();
            Console.WriteLine(result);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
