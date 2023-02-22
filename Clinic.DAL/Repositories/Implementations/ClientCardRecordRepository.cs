using System.Linq.Expressions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Abstractions;

namespace Clinic.DAL.Repositories.Implementations;

public class ClientCardRecordRepository : ReadOnlyRepositoryBase<ClientCardRecord, int>
{
    public ClientCardRecordRepository(ApplicationContext context) : base(context)
    {
    }

    protected override Expression<Func<ClientCardRecord, bool>> GetByIdExpression(int entityId)
    {
        return e => e.Id == entityId;
    }

    protected override IQueryable<ClientCardRecord> IncludeAllChildren(IQueryable<ClientCardRecord> query, bool includeAllChildren)
    {
        return query;
    }
}