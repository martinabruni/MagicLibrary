using System.Linq.Expressions;

namespace MagicLibrary.Core.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity?> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity?> UpdateAsync(TEntity entity);

        Task<TEntity?> DeleteAsync(int id);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);

        Task Save();
    }
}
