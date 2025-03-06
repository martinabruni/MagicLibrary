using MagicLibrary.Core.Business.Abstractions;
using MagicLibrary.Core.Domain;
using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Domain.Models;
using MagicLibrary.Core.Infrastructure.Models;
using System.Linq.Expressions;

namespace MagicLibrary.Core.Business.Services
{
    internal class UserService : AServiceBase<User, UserEntity>
    {
        public UserService(IRepository<UserEntity> repository, IMapper<UserEntity, User> mapper) : base(repository, mapper)
        {
        }

        public override Task<DefaultResponse<User>> AddAsync(User model, Expression<Func<UserEntity, bool>>? errorCondition)
        {
            errorCondition = (entity) => entity.Email == model.Email;
            return base.AddAsync(model, errorCondition);
        }
    }
}
