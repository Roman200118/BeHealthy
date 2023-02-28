using Clinic.BLL.Abstractions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Implementations;

namespace Clinic.BLL.Implementations;

public class PurchaseRequestService : ReadOnlyServiceBase<PurchaseRequest, PurchaseRequestRepository, int>
{
    public PurchaseRequestService(PurchaseRequestRepository repository) : base(repository)
    {
    }
}