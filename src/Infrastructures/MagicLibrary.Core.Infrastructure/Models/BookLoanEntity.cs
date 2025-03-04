using MagicLibrary.Core.Domain.Interfaces;

namespace MagicLibrary.Core.Infrastructure.Models;

public partial class BookLoanEntity : IEntity
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int UserId { get; set; }

    public DateOnly LoanDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public virtual BookEntity Book { get; set; } = null!;

    public virtual UserEntity User { get; set; } = null!;
}
