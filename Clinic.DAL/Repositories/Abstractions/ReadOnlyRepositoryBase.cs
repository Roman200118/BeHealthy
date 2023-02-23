using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Clinic.DAL.Repositories.Abstractions
{
    public abstract class ReadOnlyRepositoryBase<TEntity, TId> : RepositoryBase, IReadOnlyRepository<TEntity, TId>
        where TEntity : class
    {
        protected ReadOnlyRepositoryBase(ApplicationContext context) : base(context)
        {
        }

        public DbSet<TEntity> Set => Context.Set<TEntity>();

        public IQueryable<TEntity> QueryEntities(bool asNoTracking = true, bool includeAllChildren = true)
        {
            var query = Context.Set<TEntity>().AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return IncludeAllChildren(query, includeAllChildren);
        }

        public async Task<TEntity> GetEntityById(TId entityId, bool asNoTracking = true, bool includeAllChildren = true)
        {
            var expression = GetByIdExpression(entityId);
            var entity = await QueryEntities(asNoTracking, includeAllChildren)
                .FirstOrDefaultAsync(expression);

            return entity;
        }

        protected abstract Expression<Func<TEntity, bool>> GetByIdExpression(TId entityId);


        protected abstract IQueryable<TEntity> IncludeAllChildren(IQueryable<TEntity> query, bool includeAllChildren);
    }
}