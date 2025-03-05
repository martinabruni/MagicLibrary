using MagicLibrary.Core.Business.Abstractions;
using MagicLibrary.Core.Domain;
using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Domain.Models;
using MagicLibrary.Core.Infrastructure.Models;
using System.Linq.Expressions;

namespace MagicLibrary.Core.Business.Services
{
    internal class BookLoanService : AServiceBase<BookLoan, BookLoanEntity>
    {
        private readonly IService<Book, BookEntity> _bookService;

        public BookLoanService(IRepository<BookLoanEntity> repository, IMapper<BookLoanEntity, BookLoan> mapper, IService<Book, BookEntity> bookService) : base(repository, mapper)
        {
            _bookService = bookService;
        }

        public override async Task<DefaultResponse<BookLoan>> AddAsync(BookLoan model, Expression<Func<BookLoanEntity, bool>>? errorCondition)
        {
            DefaultResponse<BookLoan> response = new();

            errorCondition = (bl) => bl.BookId == model.Book.Id || (bl.UserId == model.User.Id && bl.ReturnDate == null);

            response = await base.AddAsync(model, errorCondition);
            if (response.StatusCode == ApplicationStatusCode.Created)
            {
                response.Data!.Book.IsAvailable = false;
                await _bookService.UpdateAsync(model.Book);
            }

            return response;
        }

        public override async Task<DefaultResponse<BookLoan>> UpdateAsync(BookLoan? model)
        {
            DefaultResponse<BookLoan> response = new();

            if (model is not null && model.Book.IsAvailable && model.ReturnDate is not null)
            {
                response.StatusCode = ApplicationStatusCode.BadRequest;
                return await Task.FromResult(response);
            }

            response = await base.UpdateAsync(model);

            if (response.StatusCode == ApplicationStatusCode.Success && response.Data!.ReturnDate is not null)
            {
                response.Data.Book.IsAvailable = true;
                await _bookService.UpdateAsync(response.Data.Book);
            }

            return response;
        }
    }
}
