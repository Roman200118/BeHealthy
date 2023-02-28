using Clinic.BLL.Abstractions;
using Clinic.DAL.Models;
using Clinic.DAL.Repositories.Implementations;

namespace Clinic.BLL.Implementations;

public class ClientCardRecordService : ReadOnlyServiceBase<ClientCardRecord, ClientCardRecordRepository, int>
{
    public ClientCardRecordService(ClientCardRecordRepository repository) : base(repository)
    {
    }
}