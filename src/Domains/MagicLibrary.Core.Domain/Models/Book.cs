using MagicLibrary.Core.Domain.Interfaces;

namespace MagicLibrary.Core.Domain.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Genre { get; set; }

        public Author Author { get; set; } = null!;
    }
}
