using Clinic.BLL.Abstractions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Implementations;

namespace Clinic.BLL.Implementations;

public class MedicamentStorageService : ReadOnlyServiceBase<MedicamentStorage, MedicamentStorageRepository, int>
{
    public MedicamentStorageService(MedicamentStorageRepository repository) : base(repository)
    {
    }
}