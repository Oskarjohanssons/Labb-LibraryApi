using Microsoft.EntityFrameworkCore;

namespace Labb_LibraryApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookID = 1,
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Author = "J.K. Rowling",
                    Genre = BookGenre.Fantasy,
                    Description = "A young boy discovers he is a wizard and attends a magical school.",
                    PublicationYear = 1997,
                    IsAvailable = true
                },
                new Book
                {
                    BookID = 2,
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Author = "J.R.R. Tolkien",
                    Genre = BookGenre.Fantasy,
                    Description = "A group of heroes embarks on a quest to destroy a powerful ring.",
                    PublicationYear = 1954,
                    IsAvailable = true
                },
                new Book
                {
                    BookID = 3,
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    Genre = BookGenre.Classic,
                    Description = "A story about a young man's experiences in New York City after being expelled from school.",
                    PublicationYear = 1951,
                    IsAvailable = false
                },
                new Book
                {
                    BookID = 4,
                    Title = "1984",
                    Author = "George Orwell",
                    Genre = BookGenre.Dystopian,
                    Description = "A dystopian novel about a totalitarian regime that uses surveillance and mind control.",
                    PublicationYear = 1949,
                    IsAvailable = true
                },
                new Book
                {
                    BookID = 5,
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Genre = BookGenre.Classic,
                    Description = "A novel about the American Dream, love, and wealth in the 1920s.",
                    PublicationYear = 1925,
                    IsAvailable = false
                },
                new Book
                {
                    BookID = 6,
                    Title = "Moby Dick",
                    Author = "Herman Melville",
                    Genre = BookGenre.Adventure,
                    Description = "The tale of Captain Ahab's obsessive quest to kill the white whale, Moby Dick.",
                    PublicationYear = 1851,
                    IsAvailable = true
                },
                new Book
                {
                    BookID = 7,
                    Title = "War and Peace",
                    Author = "Leo Tolstoy",
                    Genre = BookGenre.Historical,
                    Description = "A historical epic set during the Napoleonic Wars in Russia.",
                    PublicationYear = 1869,
                    IsAvailable = true
                },
                new Book
                {
                    BookID = 8,
                    Title = "The Da Vinci Code",
                    Author = "Dan Brown",
                    Genre = BookGenre.Mystery,
                    Description = "A symbologist uncovers a secret that could shake the foundations of Christianity.",
                    PublicationYear = 2003,
                    IsAvailable = false
                },
                new Book
                {
                    BookID = 9,
                    Title = "The Hunger Games",
                    Author = "Suzanne Collins",
                    Genre = BookGenre.Dystopian,
                    Description = "In a dystopian future, children are forced to compete in a deadly televised game.",
                    PublicationYear = 2008,
                    IsAvailable = true
                },
                new Book
                {
                    BookID = 10,
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    Genre = BookGenre.Fantasy,
                    Description = "A hobbit embarks on a journey to reclaim a treasure guarded by a dragon.",
                    PublicationYear = 1937,
                    IsAvailable = true
                });
        }

    }
}
