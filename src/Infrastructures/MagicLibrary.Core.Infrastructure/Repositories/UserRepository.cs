using MagicLibrary.Core.Infrastructure.Abstractions;
using MagicLibrary.Core.Infrastructure.Models;

namespace MagicLibrary.Core.Infrastructure.Repositories
{
    internal class UserRepository : ARepositoryBase<UserEntity>
    {
        public UserRepository(SqldbMagiclibraryCoreDevContext context) : base(context)
        {
        }
    }
}
