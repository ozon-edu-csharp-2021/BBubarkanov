using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Api.Models;

namespace MerchandiseService.HttpClient
{
    public interface IMerchandiseHttpClient
    {
        Task<MerchResponse> GetMerch(CancellationToken token);
        Task<MerchInfoResponse> GetMerchInfo(CancellationToken token);
    }
}
