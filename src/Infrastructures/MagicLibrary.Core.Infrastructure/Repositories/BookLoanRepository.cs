using MagicLibrary.Core.Infrastructure.Abstractions;
using MagicLibrary.Core.Infrastructure.Models;

namespace MagicLibrary.Core.Infrastructure.Repositories
{
    internal class BookLoanRepository : ARepositoryBase<BookLoanEntity>
    {
        public BookLoanRepository(SqldbMagiclibraryCoreDevContext context) : base(context)
        {
        }
    }
}
