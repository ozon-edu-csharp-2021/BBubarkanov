using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Api.Models;

namespace MerchandiseService.HttpClient
{
    public interface IMerchandiseHttpClient
    {
        Task<Merch> GetMerch(CancellationToken token);
        Task<MerchInfo> GetMerchInfo(CancellationToken token);
    }
}
