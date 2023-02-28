using Clinic.BLL.Abstractions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Implementations;

namespace Clinic.BLL.Implementations;

public class DoctorReferralService : ReadOnlyServiceBase<DoctorReferral, DoctorReferralRepository, int>
{
    public DoctorReferralService(DoctorReferralRepository repository) : base(repository)
    {
    }
}