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
            modelBuilder.Entity<Books>(o =>
            {
                o.ToTable("Books", "Library");
                o.HasKey(x => x.BooksID);
                o.Property(x => x.BooksID);
                o.Property(x => x.BookName);
            });
            modelBuilder.Entity<Author>(o =>
            {
                o.ToTable("Author", "Library");
                o.HasKey(x => x.AuthorID);
                o.Property(x => x.AuthorID);
                o.Property(x => x.AuthorName);
                o.HasMany(x => x.Books)
                .WithMany(t => t.Author);
            });
            modelBuilder.Entity<BooksAndAuthors>(o =>
            {
                o.ToTable("BooksAndAuthors", "Library");
                o.Property(x => x.BooksID);
                o.Property(x => x.AuthorID);
            });
            modelBuilder.Entity<BooksAndAuthors>()
                .HasKey(x => new {x.AuthorID,x.BooksID});
        }

    
    }
}