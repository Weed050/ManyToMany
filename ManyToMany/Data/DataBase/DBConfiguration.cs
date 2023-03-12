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

            builder.HasMany(b => b.Books)
                .WithMany(b => b.Author)
                .UsingEntity<BooksAndAuthors>( 
               o => o.HasOne(y => y.Books).WithMany().HasForeignKey(y => y.BooksID),
               o => o.HasOne(x => x.Author).WithMany().HasForeignKey(x => x.AuthorID),
               o => {
                   o.HasKey(z => new { z.AuthorID, z.BooksID });
                   o.Property(x => x.AddingTime).HasDefaultValueSql("GETUTCDATE()");
               }
               );
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
            builder.Property(x => x.AddingTime);
        }

    }
}
