using System.Linq.Expressions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Abstractions;

namespace Clinic.DAL.Repositories.Implementations;

public class MedicamentStorageRepository : ReadOnlyRepositoryBase<MedicamentStorage, int>
{
    public MedicamentStorageRepository(ApplicationContext context) : base(context)
    {
    }

    protected override Expression<Func<MedicamentStorage, bool>> GetByIdExpression(int entityId)
    {
        return e => e.Id == entityId;
    }

    protected override IQueryable<MedicamentStorage> IncludeAllChildren(IQueryable<MedicamentStorage> query, bool includeAllChildren)
    {
        return query;
    }
}