namespace MagicLibrary.Core.Domain.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string Name { get; set; } = null!;

        public DateOnly? BirthDate { get; set; }
    }
}
