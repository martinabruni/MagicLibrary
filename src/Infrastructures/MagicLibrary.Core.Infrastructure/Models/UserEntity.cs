using MagicLibrary.Core.Domain.Interfaces;

namespace MagicLibrary.Core.Infrastructure.Models;

public partial class UserEntity : IEntity
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly? MembershipDate { get; set; }

    public virtual ICollection<BookLoanEntity> BookLoans { get; set; } = new List<BookLoanEntity>();
}
