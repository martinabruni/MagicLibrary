using MagicLibrary.Core.Domain.Interfaces;

namespace MagicLibrary.Core.Domain.Models
{
    public class BookLoan : IEntity
    {
        public int Id { get; set; }

        public Book Book { get; set; } = null!;

        public User User { get; set; } = null!;

        public DateOnly LoanDate { get; set; }

        public DateOnly? ReturnDate { get; set; }
    }
}
