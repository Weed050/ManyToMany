using ManyToMany.Data.DataBase;
using ManyToMany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManyToMany.Data
{
    public class ManyToManyDBContext : DbContext
    {
        public ManyToManyDBContext(DbContextOptions options): base(options) { }

        public DbSet<Author> Author { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BooksAndAuthors> BooksAndAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BooksAndAuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BooksConfiguration());
        }

    
    }
}