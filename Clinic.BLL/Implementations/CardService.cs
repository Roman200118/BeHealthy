using Clinic.BLL.Abstractions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Implementations;

namespace Clinic.BLL.Implementations;

public class CardService : ReadOnlyServiceBase<ClientCard, CardRepository, int>
{
    public CardService(CardRepository repository) : base(repository)
    {
    }
}