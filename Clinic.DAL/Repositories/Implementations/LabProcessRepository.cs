using System.Linq.Expressions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Abstractions;

namespace Clinic.DAL.Repositories.Implementations;

public class LabProcessRepository : ReadOnlyRepositoryBase<LabProcess, int>
{
    public LabProcessRepository(ApplicationContext context) : base(context)
    {
    }

    protected override Expression<Func<LabProcess, bool>> GetByIdExpression(int entityId)
    {
        return e => e.Id == entityId;
    }

    protected override IQueryable<LabProcess> IncludeAllChildren(IQueryable<LabProcess> query, bool includeAllChildren)
    {
        return query;
    }
}