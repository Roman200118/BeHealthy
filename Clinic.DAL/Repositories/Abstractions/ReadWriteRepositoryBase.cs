namespace Clinic.DAL.Repositories.Abstractions
{
    public abstract class ReadWriteRepositoryBase<TCreateModel, TEntity, TId> : ReadOnlyRepositoryBase<TEntity, TId>, IReadWriteRepository<TCreateModel, TEntity, TId>
        where TCreateModel : class
        where TEntity : class
    {
        protected ReadWriteRepositoryBase(ApplicationContext context) : base(context)
        {
        }

        public abstract Task<TEntity> Create(TCreateModel model);
    }
}