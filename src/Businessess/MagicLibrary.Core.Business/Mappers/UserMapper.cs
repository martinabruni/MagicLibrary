using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Domain.Models;
using MagicLibrary.Core.Infrastructure.Models;

namespace MagicLibrary.Core.Business.Mappers
{
    internal class UserMapper : IMapper<UserEntity, User>
    {
        public User MapToDomain(UserEntity entity)
        {
            return new User
            {
                Id = entity.Id,
                Email = entity.Email,
                FullName = entity.FullName,
                MembershipDate = entity.MembershipDate,
            };
        }
        public UserEntity MapToEntity(User domain)
        {
            return new UserEntity
            {
                Email = domain.Email,
                FullName = domain.FullName,
                MembershipDate = domain.MembershipDate
            };
        }
    }
}
