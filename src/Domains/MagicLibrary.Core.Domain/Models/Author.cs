using MagicLibrary.Core.Domain.Interfaces;

namespace MagicLibrary.Core.Domain.Models
{
    public class Author : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateOnly? BirthDate { get; set; }
    }
}
