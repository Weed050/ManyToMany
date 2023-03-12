using ManyToMany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManyToMany.Data.DataBase
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {

        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author", "Library");
            builder.HasKey(x => x.AuthorID);
            builder.Property(x => x.AuthorID);
            builder.Property(x => x.AuthorName);

        }
    }
    public class BooksConfiguration : IEntityTypeConfiguration<Books>
    {

        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.ToTable("Books", "Library");
            builder.HasKey(x => x.BooksID);
            builder.Property(x => x.BooksID);
            builder.Property(x => x.BookName);

        }

    }
    public class BooksAndAuthorConfiguration : IEntityTypeConfiguration<BooksAndAuthors>
    {

        public void Configure(EntityTypeBuilder<BooksAndAuthors> builder)
        {
            builder.ToTable("BooksAndAuthors", "Library");
            builder.HasKey(x => new {x.AuthorID,x.BooksID});
            builder.Property(x => x.BooksID);
            builder.Property(x => x.AuthorID);
            builder.Property(x => x.AddingTime).HasDefaultValueSql("getutcdate()");

            
        }

    }
}
