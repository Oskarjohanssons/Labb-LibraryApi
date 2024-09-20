﻿// <auto-generated />
using Labb_LibraryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb_LibraryApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb_LibraryApi.Data.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BookID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookID = 1,
                            Author = "J.K. Rowling",
                            Description = "A young boy discovers he is a wizard and attends a magical school.",
                            Genre = 2,
                            IsAvailable = true,
                            PublicationYear = 1997,
                            Title = "Harry Potter and the Sorcerer's Stone"
                        },
                        new
                        {
                            BookID = 2,
                            Author = "J.R.R. Tolkien",
                            Description = "A group of heroes embarks on a quest to destroy a powerful ring.",
                            Genre = 2,
                            IsAvailable = true,
                            PublicationYear = 1954,
                            Title = "The Lord of the Rings: The Fellowship of the Ring"
                        },
                        new
                        {
                            BookID = 3,
                            Author = "J.D. Salinger",
                            Description = "A story about a young man's experiences in New York City after being expelled from school.",
                            Genre = 5,
                            IsAvailable = false,
                            PublicationYear = 1951,
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            BookID = 4,
                            Author = "George Orwell",
                            Description = "A dystopian novel about a totalitarian regime that uses surveillance and mind control.",
                            Genre = 6,
                            IsAvailable = true,
                            PublicationYear = 1949,
                            Title = "1984"
                        },
                        new
                        {
                            BookID = 5,
                            Author = "F. Scott Fitzgerald",
                            Description = "A novel about the American Dream, love, and wealth in the 1920s.",
                            Genre = 5,
                            IsAvailable = false,
                            PublicationYear = 1925,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            BookID = 6,
                            Author = "Herman Melville",
                            Description = "The tale of Captain Ahab's obsessive quest to kill the white whale, Moby Dick.",
                            Genre = 7,
                            IsAvailable = true,
                            PublicationYear = 1851,
                            Title = "Moby Dick"
                        },
                        new
                        {
                            BookID = 7,
                            Author = "Leo Tolstoy",
                            Description = "A historical epic set during the Napoleonic Wars in Russia.",
                            Genre = 8,
                            IsAvailable = true,
                            PublicationYear = 1869,
                            Title = "War and Peace"
                        },
                        new
                        {
                            BookID = 8,
                            Author = "Dan Brown",
                            Description = "A symbologist uncovers a secret that could shake the foundations of Christianity.",
                            Genre = 4,
                            IsAvailable = false,
                            PublicationYear = 2003,
                            Title = "The Da Vinci Code"
                        },
                        new
                        {
                            BookID = 9,
                            Author = "Suzanne Collins",
                            Description = "In a dystopian future, children are forced to compete in a deadly televised game.",
                            Genre = 6,
                            IsAvailable = true,
                            PublicationYear = 2008,
                            Title = "The Hunger Games"
                        },
                        new
                        {
                            BookID = 10,
                            Author = "J.R.R. Tolkien",
                            Description = "A hobbit embarks on a journey to reclaim a treasure guarded by a dragon.",
                            Genre = 2,
                            IsAvailable = true,
                            PublicationYear = 1937,
                            Title = "The Hobbit"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
