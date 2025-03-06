using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Domain.Models;
using MagicLibrary.Core.Infrastructure.Models;

namespace MagicLibrary.Core.Business.Mappers
{
    internal class BookLoanMapper : IMapper<BookLoanEntity, BookLoan>
    {
        private readonly IMapper<BookEntity, Book> _bookMapper;

        private readonly IMapper<UserEntity, User> _userMapper;

        public BookLoanMapper(IMapper<UserEntity, User> userMapper, IMapper<BookEntity, Book> bookMapper)
        {
            _userMapper = userMapper;
            _bookMapper = bookMapper;
        }

        public BookLoan MapToDomain(BookLoanEntity entity)
        {
            return new BookLoan
            {
                Id = entity.Id,
                Book = _bookMapper.MapToDomain(entity.Book),
                User = _userMapper.MapToDomain(entity.User),
                LoanDate = entity.LoanDate,
                ReturnDate = entity.ReturnDate,
            };
        }

        public BookLoanEntity MapToEntity(BookLoan domain)
        {
            return new BookLoanEntity
            {
                BookId = domain.Book.Id,
                UserId = domain.User.Id,
                LoanDate = domain.LoanDate,
                ReturnDate = domain.ReturnDate,
            };
        }
    }
}
