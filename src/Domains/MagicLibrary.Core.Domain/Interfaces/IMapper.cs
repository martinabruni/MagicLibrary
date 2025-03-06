namespace MagicLibrary.Core.Domain.Interfaces
{
    public interface IMapper<TEntity, TDomain> where TEntity : IEntity where TDomain : IEntity
    {
        TEntity MapToEntity(TDomain domain);

        TDomain MapToDomain(TEntity entity);
    }
}
