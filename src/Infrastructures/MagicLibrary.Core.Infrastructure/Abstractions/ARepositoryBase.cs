using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<TEntity?> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await Save();
            return entity;
        }

        public virtual async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            var dbEntity = await _dbSet.FindAsync(entity.Id);

            if (dbEntity is null)
                return null;

            _context.Entry(dbEntity).State = EntityState.Detached;
            _context.Update(entity);
            await Save();
            return entity;
        }

        public virtual async Task<TEntity?> DeleteAsync(TEntity dbEntity)
        {
            if (dbEntity is null)
                return null;

            _context.Remove(dbEntity);
            await Save();
            return dbEntity;
        }

        public virtual async Task<TEntity?> DeleteAsync(int id)
        {
            var dbEntity = await _dbSet.FindAsync(id);

            if (dbEntity is null)
                return null;

            _context.Remove(dbEntity);
            await Save();
            return dbEntity;
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter) => await _dbSet.AnyAsync(filter);

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter) => await _dbSet.Where(filter).ToListAsync();
    }
}
