using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Domain.Models;
using MagicLibrary.Core.Infrastructure.Models;

namespace MagicLibrary.Core.Business.Mappers
{
    internal class AuthorMapper : IMapper<AuthorEntity, Author>
    {
        public Author MapToDomain(AuthorEntity entity)
        {
            return new Author
            {
                Id = entity.Id,
                Name = entity.Name,
                BirthDate = entity.BirthDate,
            };
        }

        public AuthorEntity MapToEntity(Author domain)
        {
            return new AuthorEntity
            {
                Name = domain.Name,
                BirthDate = domain.BirthDate,
            };
        }
    }
}
