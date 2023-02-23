namespace Clinic.DAL.Repositories.Abstractions
{
    public interface IReadWriteRepository<in TCreateModel, TEntity, TId> : IReadOnlyRepository<TEntity, TId>
    {
        public Task<TEntity> Create(TCreateModel model);
    }
}
