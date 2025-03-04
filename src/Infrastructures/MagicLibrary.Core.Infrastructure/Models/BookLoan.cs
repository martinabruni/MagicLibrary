using System;
using System.Collections.Generic;

namespace MagicLibrary.Core.Infrastructure.Models;

public partial class BookLoan
{
    public int LoanId { get; set; }

    public int BookId { get; set; }

    public int UserId { get; set; }

    public DateOnly LoanDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
