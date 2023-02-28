namespace Clinic.BLL.Abstractions;

public interface IReadOnlyService<TEntity, TId>
{
    public IQueryable<TEntity> GetEntities(bool asNoTracking = true, bool includeAllChildren = true);
    public Task<TEntity> GetEntityById(TId entityId, bool asNoTracking = true, bool includeAllChildren = true);
}