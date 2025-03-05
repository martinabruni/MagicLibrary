using MagicLibrary.Core.Domain;
using MagicLibrary.Core.Domain.Interfaces;
using System.Linq.Expressions;

namespace MagicLibrary.Core.Business.Abstractions
{
    public class AServiceBase<TDomain, TEntity> : IService<TDomain, TEntity> where TDomain : IEntity where TEntity : IEntity
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper<TEntity, TDomain> _mapper;

        public AServiceBase(IRepository<TEntity> repository, IMapper<TEntity, TDomain> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async virtual Task<DefaultResponse<TDomain>> AddAsync(TDomain model, Expression<Func<TEntity, bool>>? errorCondition)
        {
            DefaultResponse<TDomain> response = new();
            if (model is null || (errorCondition is not null && await _repository.ExistsAsync(errorCondition)))
                response.StatusCode = ApplicationStatusCode.BadRequest;
            else
            {
                var entity = _mapper.MapToEntity(model!);
                var result = await _repository.AddAsync(entity);
                response.Data = _mapper.MapToDomain(result);
                response.StatusCode = ApplicationStatusCode.Created;
            }

            return response;

        }

        public async virtual Task<DefaultResponse<TDomain>> DeleteAsync(int id)
        {
            DefaultResponse<TDomain> response = new();
            if (id <= 0)
                response.StatusCode = ApplicationStatusCode.BadRequest;
            else
            {
                var result = await _repository.DeleteAsync(id);
                response.Data = _mapper.MapToDomain(result!);
                response.StatusCode = ApplicationStatusCode.Success;
            }

            return response;
        }

        public async virtual Task<DefaultResponse<IEnumerable<TDomain>>> GetAllAsync()
        {
            DefaultResponse<IEnumerable<TDomain>> response = new()
            {
                Data = (await _repository.GetAllAsync()).Select(_mapper.MapToDomain),
                StatusCode = ApplicationStatusCode.Success
            };
            return response;
        }

        public async virtual Task<DefaultResponse<TDomain>> GetByIdAsync(int id)
        {
            DefaultResponse<TDomain> response = new();
            if (id <= 0)
                response.StatusCode = ApplicationStatusCode.BadRequest;
            else
            {
                var result = await _repository.GetByIdAsync(id);
                response.Data = _mapper.MapToDomain(result!);
                response.StatusCode = ApplicationStatusCode.Success;
            }
            return response;
        }

        public async virtual Task<DefaultResponse<TDomain>> UpdateAsync(TDomain? model)
        {
            DefaultResponse<TDomain> response = new();
            if (model is null)
                response.StatusCode = ApplicationStatusCode.BadRequest;
            else
            {
                var entity = _mapper.MapToEntity(model!);
                var result = await _repository.UpdateAsync(entity);
                if (result is null)
                    response.StatusCode = ApplicationStatusCode.BadRequest;
                else
                {
                    response.Data = _mapper.MapToDomain(result!);
                    response.StatusCode = ApplicationStatusCode.Success;
                }
            }
            return response;
        }
    }
}
