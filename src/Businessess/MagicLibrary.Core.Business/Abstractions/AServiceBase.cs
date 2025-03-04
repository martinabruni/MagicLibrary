using MagicLibrary.Core.Domain;
using MagicLibrary.Core.Domain.Interfaces;

namespace MagicLibrary.Core.Business.Abstractions
{
    public class AServiceBase<TDomain> : IService<TDomain> where TDomain : IEntity
    {
        public Task<DefaultResponse<TDomain>> AddAsync(TDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task<DefaultResponse<TDomain>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DefaultResponse<IEnumerable<TDomain>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DefaultResponse<TDomain>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DefaultResponse<TDomain>> UpdateAsync(TDomain entity)
        {
            throw new NotImplementedException();
        }
    }
}
