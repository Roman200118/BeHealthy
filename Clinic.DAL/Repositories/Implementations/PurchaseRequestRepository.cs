using System.Linq.Expressions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Abstractions;

namespace Clinic.DAL.Repositories.Implementations;

public class PurchaseRequestRepository : ReadOnlyRepositoryBase<PurchaseRequest, int>
{
    public PurchaseRequestRepository(ApplicationContext context) : base(context)
    {
    }

    protected override Expression<Func<PurchaseRequest, bool>> GetByIdExpression(int entityId)
    {
        return e => e.Id == entityId;
    }

    protected override IQueryable<PurchaseRequest> IncludeAllChildren(IQueryable<PurchaseRequest> query, bool includeAllChildren)
    {
        return query;
    }
}