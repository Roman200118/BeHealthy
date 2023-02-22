using System.Linq.Expressions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Abstractions;

namespace Clinic.DAL.Repositories.Implementations;

public class DoctorReferralRepository : ReadOnlyRepositoryBase<DoctorReferral, int>
{
    public DoctorReferralRepository(ApplicationContext context) : base(context)
    {
    }

    protected override Expression<Func<DoctorReferral, bool>> GetByIdExpression(int entityId)
    {
        return e => e.Id == entityId;
    }

    protected override IQueryable<DoctorReferral> IncludeAllChildren(IQueryable<DoctorReferral> query, bool includeAllChildren)
    {
        return query;
    }
}