using Clinic.BLL.Abstractions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Implementations;

namespace Clinic.BLL.Implementations;

public class LabProcessService : ReadOnlyServiceBase<LabProcess, LabProcessRepository, int>
{
    public LabProcessService(LabProcessRepository repository) : base(repository)
    {
    }
}