using MagicLibrary.Core.Infrastructure.Abstractions;
using MagicLibrary.Core.Infrastructure.Models;

namespace MagicLibrary.Core.Infrastructure.Repositories
{
    internal class BookRepository : ARepositoryBase<BookEntity>
    {
        public BookRepository(SqldbMagiclibraryCoreDevContext context) : base(context)
        {
        }
    }
}
