using System.Linq.Expressions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Abstractions;

namespace Clinic.DAL.Repositories.Implementations;

public class StorageRequestRepository : ReadOnlyRepositoryBase<StorageRequest, int>
{
    public StorageRequestRepository(ApplicationContext context) : base(context)
    {
    }

    protected override Expression<Func<StorageRequest, bool>> GetByIdExpression(int entityId)
    {
        return e => e.Id == entityId;
    }

    protected override IQueryable<StorageRequest> IncludeAllChildren(IQueryable<StorageRequest> query, bool includeAllChildren)
    {
        return query;
    }
}