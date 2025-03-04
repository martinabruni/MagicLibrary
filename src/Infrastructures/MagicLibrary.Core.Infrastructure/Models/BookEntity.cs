using MagicLibrary.Core.Domain.Interfaces;

namespace MagicLibrary.Core.Infrastructure.Models;

public partial class BookEntity : IEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Genre { get; set; }

    public int AuthorId { get; set; }

    public virtual AuthorEntity Author { get; set; } = null!;

    public virtual ICollection<BookLoanEntity> BookLoans { get; set; } = new List<BookLoanEntity>();
}
