using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicLibrary.Core.Infrastructure.Abstractions
{
    public class ARepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly SqldbMagiclibraryCoreDevContext _context;

        protected readonly DbSet<TEntity> _dbSet;

        public ARepositoryBase(SqldbMagiclibraryCoreDevContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await Save();
            return entity;
        }

        public async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            var dbEntity = await _dbSet.FindAsync(entity.Id);

            if (dbEntity is null)
                return null;

            _context.Entry(dbEntity).State = EntityState.Detached;
            _context.Update(entity);
            await Save();
            return dbEntity;
        }

        public async Task<TEntity?> DeleteAsync(int id)
        {
            var dbEntity = await _dbSet.FindAsync(id);

            if (dbEntity is null)
                return null;

            _context.Remove(dbEntity);
            await Save();
            return dbEntity;
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter) => await _dbSet.AnyAsync(filter);

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter) => await _dbSet.Where(filter).ToListAsync();
    }
}
