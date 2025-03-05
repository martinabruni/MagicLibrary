using MagicLibrary.Core.Business.Abstractions;
using MagicLibrary.Core.Domain;
using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Domain.Models;
using MagicLibrary.Core.Infrastructure.Models;
using System.Linq.Expressions;

namespace MagicLibrary.Core.Business.Services
{
    internal class BookService : AServiceBase<Book, BookEntity>
    {
        private readonly IRepository<AuthorEntity> _authorRepository;
        private readonly IService<Author, AuthorEntity> _authorService;

        public BookService(IRepository<BookEntity> repository, IMapper<BookEntity, Book> mapper, IRepository<AuthorEntity> authorRepository, IService<Author, AuthorEntity> authorService) : base(repository, mapper)
        {
            _authorRepository = authorRepository;
            _authorService = authorService;
        }

        public override async Task<DefaultResponse<Book>> AddAsync(Book model, Expression<Func<BookEntity, bool>>? errorCondition)
        {
            DefaultResponse<Book> response = new();
            if (model.Author is null)
            {
                response.StatusCode = ApplicationStatusCode.BadRequest;
                return await Task.FromResult(response);
            }

            var authorExists = _authorRepository.ExistsAsync(a => a.Id == model.Author.Id);

            if (!authorExists.Result)
                await _authorService.AddAsync(model.Author);

            return await base.AddAsync(model, errorCondition);
        }
    }
}
