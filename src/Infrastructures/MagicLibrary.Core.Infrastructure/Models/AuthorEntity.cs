using MagicLibrary.Core.Domain.Interfaces;

namespace MagicLibrary.Core.Infrastructure.Models;

public partial class AuthorEntity : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public virtual ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();
}
