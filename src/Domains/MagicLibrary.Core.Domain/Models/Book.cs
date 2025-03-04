namespace MagicLibrary.Core.Domain.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; } = null!;

        public string? Genre { get; set; }

        public Author Author { get; set; } = null!;
    }
}
