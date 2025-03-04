using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Domain.Models;
using MagicLibrary.Core.Infrastructure.Models;

namespace MagicLibrary.Core.Business.Mappers
{
    internal class BookMapper : IMapper<BookEntity, Book>
    {
        public Book MapToDomain(BookEntity entity)
        {
            return new Book
            {
                Id = entity.Id,
                Title = entity.Title,
                Genre = entity.Genre,
                Author = new Author
                {
                    Id = entity.Author.Id,
                    Name = entity.Author.Name,
                    BirthDate = entity.Author.BirthDate,
                },
            };
        }

        public BookEntity MapToEntity(Book domain)
        {
            return new BookEntity
            {
                Id = domain.Id,
                Title = domain.Title,
                Genre = domain.Genre,
                AuthorId = domain.Author.Id,
            };
        }
    }
}
