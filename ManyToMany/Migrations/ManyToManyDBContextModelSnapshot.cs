﻿// <auto-generated />
using System;
using ManyToMany.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManyToMany.Migrations
{
    [DbContext(typeof(ManyToManyDBContext))]
    partial class ManyToManyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ManyToMany.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorID");

                    b.ToTable("Author", "Library");
                });

            modelBuilder.Entity("ManyToMany.Models.Books", b =>
                {
                    b.Property<int>("BooksID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BooksID"));

                    b.Property<int>("BookName")
                        .HasColumnType("int");

                    b.HasKey("BooksID");

                    b.ToTable("Books", "Library");
                });

            modelBuilder.Entity("ManyToMany.Models.BooksAndAuthors", b =>
                {
                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int>("BooksID")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddingTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("gerutcdate()");

                    b.HasKey("AuthorID", "BooksID");

                    b.HasIndex("BooksID");

                    b.ToTable("BooksAndAuthors", "Library");
                });

            modelBuilder.Entity("ManyToMany.Models.BooksAndAuthors", b =>
                {
                    b.HasOne("ManyToMany.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManyToMany.Models.Books", "Books")
                        .WithMany()
                        .HasForeignKey("BooksID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
