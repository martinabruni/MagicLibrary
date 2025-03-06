using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Infrastructure.Abstractions;
using MagicLibrary.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicLibrary.Core.Infrastructure.Repositories
{
    internal class BookRepository : ARepositoryBase<BookEntity>
    {
        private readonly IRepository<AuthorEntity> _authorRepository;

        public BookRepository(SqldbMagiclibraryCoreDevContext context, IRepository<AuthorEntity> authorRepository) : base(context)
        {
            _authorRepository = authorRepository;
        }

        public override async Task<BookEntity> AddAsync(BookEntity entity)
        {
            var author = await _authorRepository.GetByIdAsync(entity.AuthorId);
            entity.Author = author!;
            return await base.AddAsync(entity);
        }

        public override async Task<IEnumerable<BookEntity>> GetAllAsync()
        {
            return await base.GetAllAsync(b => b.Author);
        }

        public override async Task<BookEntity?> DeleteAsync(int id)
        {
            var dbEntity = await GetByIdAsync(id);
            return await base.DeleteAsync(dbEntity!);
        }

        public override async Task<BookEntity?> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id, b => b.Author);
        }
    }
}
