using Microsoft.EntityFrameworkCore;

namespace Clinic.DAL.Repositories.Abstractions
{
    public abstract class RepositoryBase : IDisposable
    {
        private bool _disposed;

        protected ApplicationContext Context { get; }

        protected RepositoryBase(ApplicationContext context)
        {
            Context = context;
        }

        protected void DetachEntities<TEntity>(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Context.Entry(entity).State = EntityState.Detached;
            }
        }

        #region IDisposable implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Context.Dispose();
            }

            _disposed = true;
        }
        #endregion
    }
}