namespace MagicLibrary.Core.Domain.Interfaces
{
    public interface IService<TDomain> where TDomain : IEntity
    {
        Task<DefaultResponse<TDomain>> GetByIdAsync(int id);

        Task<DefaultResponse<IEnumerable<TDomain>>> GetAllAsync();

        Task<DefaultResponse<TDomain>> AddAsync(TDomain entity);

        Task<DefaultResponse<TDomain>> UpdateAsync(TDomain entity);

        Task<DefaultResponse<TDomain>> DeleteAsync(int id);
    }
}
