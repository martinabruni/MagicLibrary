using System.Linq.Expressions;

namespace MagicLibrary.Core.Domain.Interfaces
{
    public interface IService<TDomain, TEntity> where TDomain : IEntity where TEntity : IEntity
    {
        Task<DefaultResponse<TDomain>> GetByIdAsync(int id);

        Task<DefaultResponse<IEnumerable<TDomain>>> GetAllAsync();

        Task<DefaultResponse<TDomain>> AddAsync(TDomain model, Expression<Func<TEntity, bool>>? errorCondition = null);

        Task<DefaultResponse<TDomain>> UpdateAsync(TDomain? model);

        Task<DefaultResponse<TDomain>> DeleteAsync(int id);
    }
}
