using MagicLibrary.Core.Business.Abstractions;
using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Domain.Models;
using MagicLibrary.Core.Infrastructure.Models;

namespace MagicLibrary.Core.Business.Services
{
    internal class AuthorService : AServiceBase<Author, AuthorEntity>
    {
        public AuthorService(IRepository<AuthorEntity> repository, IMapper<AuthorEntity, Author> mapper) : base(repository, mapper)
        {
        }
    }
}
