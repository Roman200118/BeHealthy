using System.Linq.Expressions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Abstractions;

namespace Clinic.DAL.Repositories.Implementations;

public class CardRepository : ReadOnlyRepositoryBase<ClientCard, int>
{
    public CardRepository(ApplicationContext context) : base(context)
    {
    }

    protected override Expression<Func<ClientCard, bool>> GetByIdExpression(int entityId)
    {
        return e => e.Id == entityId;
    }

    protected override IQueryable<ClientCard> IncludeAllChildren(IQueryable<ClientCard> query, bool includeAllChildren)
    {
        return query;
    }
}