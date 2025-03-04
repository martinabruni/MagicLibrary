using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Domain.Models;
using MagicLibrary.Core.Infrastructure.Models;

namespace MagicLibrary.Core.Business.Mappers
{
    internal class BookLoanMapper : IMapper<BookLoanEntity, BookLoan>
    {
        public BookLoan MapToDomain(BookLoanEntity entity)
        {
            return new BookLoan
            {
                Id = entity.Id,
                Book = new Book
                {
                    Id = entity.BookId,
                    Author = new Author
                    {
                        Id = entity.Book.AuthorId,
                        Name = entity.Book.Author.Name,
                        BirthDate = entity.Book.Author.BirthDate,
                    },
                    Title = entity.Book.Title,
                    Genre = entity.Book.Genre,
                },
                User = new User
                {
                    Id = entity.UserId,
                    FullName = entity.User.FullName,
                    Email = entity.User.Email,
                    MembershipDate = entity.User.MembershipDate,
                },
                LoanDate = entity.LoanDate,
                ReturnDate = entity.ReturnDate,
            };
        }

        public BookLoanEntity MapToEntity(BookLoan domain)
        {
            return new BookLoanEntity
            {
                Id = domain.Id,
                BookId = domain.Book.Id,
                UserId = domain.User.Id,
                LoanDate = domain.LoanDate,
                ReturnDate = domain.ReturnDate,
            };
        }
    }
}
