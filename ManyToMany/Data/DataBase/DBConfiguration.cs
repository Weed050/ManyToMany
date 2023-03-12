//using ManyToMany.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace ManyToMany.Data.DataBase
//{
//    public class DBConfiguration : IEntityTypeConfiguration<Author>
//    {
       
//        public void Configure(EntityTypeBuilder<Author> builder)
//        {
//            builder.ToTable("Author", "Library");
//            builder.HasKey(x => x.AuthorID);
//            builder.Property(x => x.AuthorID);
//            builder.Property(x => x.AuthorName);

//        }
//    }
//}
