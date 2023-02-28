using Clinic.DAL.Repositories.Abstractions;

namespace Clinic.BLL.Abstractions;

public abstract class ReadOnlyServiceBase<TEntity, TRepository, TId> : IReadOnlyService<TEntity, TId>
    where TEntity : class
    where TRepository : IReadOnlyRepository<TEntity, TId>
{
    protected TRepository Repository { get; }

    protected ReadOnlyServiceBase(TRepository repository)
    {
        Repository = repository;
    }

    public virtual IQueryable<TEntity> GetEntities(bool asNoTracking = true, bool includeAllChildren = true)
    {
        var entities = Repository.QueryEntities(asNoTracking, includeAllChildren);

        return entities;
    }

    public Task<TEntity> GetEntityById(TId entityId, bool asNoTracking = true, bool includeAllChildren = true)
    {
        var entity = Repository.GetEntityById(entityId, asNoTracking, includeAllChildren);

        return entity;
    }
}