using CRUP.MinimalAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRUP.MinimalAPI.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().HasData(
                new Livro
                {
                    Id = 1,
                    Titutlo = "Clean Code",
                    Autor = "Robert C. Martin"
                },
                new Livro
                {
                    Id = 2,
                    Titutlo = "Clean Architecture",
                    Autor = "Robert C. Martin"
                },
                new Livro
                {
                    Id = 3,
                    Titutlo = "Programming Entity Framework Core",
                    Autor = "Julia Lerman"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
