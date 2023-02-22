namespace Clinic.DAL.Repositories.Abstractions
{
    public interface IReadOnlyRepository<TEntity, TId>
    {
        public Task<TEntity> GetEntityById(TId entityId, bool asNoTracking = true, bool includeAllChildren = true);

        public IQueryable<TEntity> QueryEntities(bool asNoTracking = true, bool includeAllChildren = true);
    }
}
