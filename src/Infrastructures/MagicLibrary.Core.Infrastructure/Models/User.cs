using System;
using System.Collections.Generic;

namespace MagicLibrary.Core.Infrastructure.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly? MembershipDate { get; set; }

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
}
