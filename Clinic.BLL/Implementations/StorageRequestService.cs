using Clinic.BLL.Abstractions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Implementations;

namespace Clinic.BLL.Implementations;

public class StorageRequestService : ReadOnlyServiceBase<StorageRequest, StorageRequestRepository, int>
{
    public StorageRequestService(StorageRequestRepository repository) : base(repository)
    {
    }
}