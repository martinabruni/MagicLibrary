using MagicLibrary.Core.Business.Abstractions;
using MagicLibrary.Core.Domain;
using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Domain.Models;
using MagicLibrary.Core.Infrastructure.Models;
using System.Linq.Expressions;

namespace MagicLibrary.Core.Business.Services
{
    internal class AuthorService : AServiceBase<Author, AuthorEntity>
    {
        public AuthorService(IRepository<AuthorEntity> repository, IMapper<AuthorEntity, Author> mapper) : base(repository, mapper)
        {
        }

        public override Task<DefaultResponse<Author>> AddAsync(Author model, Expression<Func<AuthorEntity, bool>>? errorCondition)
        {
            errorCondition = (a => a.Name == model.Name);
            return base.AddAsync(model, errorCondition);
        }
    }
}
