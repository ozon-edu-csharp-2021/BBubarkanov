using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Api.Models;

namespace MerchandiseService.HttpClient
{
    public interface IMerchandiseHttpClient
    {
        Task<RequestStatusOutputModel> GetMerch(CancellationToken token);
        Task<EmployeeRequestsOutputModel> GetMerchInfo(CancellationToken token);
    }
}
