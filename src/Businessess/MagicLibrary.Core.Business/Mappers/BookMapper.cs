using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Domain.Models;
using MagicLibrary.Core.Infrastructure.Models;

namespace MagicLibrary.Core.Business.Mappers
{
    internal class BookMapper : IMapper<BookEntity, Book>
    {
        private readonly IMapper<AuthorEntity, Author> _authorMapper;

        public BookMapper(IMapper<AuthorEntity, Author> authorMapper)
        {
            _authorMapper = authorMapper;
        }

        public Book MapToDomain(BookEntity entity)
        {
            return new Book
            {
                Id = entity.Id,
                Title = entity.Title,
                Genre = entity.Genre,
                Author = _authorMapper.MapToDomain(entity.Author),
            };
        }

        public BookEntity MapToEntity(Book domain)
        {
            return new BookEntity
            {
                Title = domain.Title,
                Genre = domain.Genre,
                AuthorId = domain.Author.Id,
                Author = _authorMapper.MapToEntity(domain.Author),
            };
        }
    }
}
