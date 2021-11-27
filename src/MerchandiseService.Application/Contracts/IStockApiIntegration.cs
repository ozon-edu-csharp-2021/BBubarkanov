using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Application.Contracts
{
    public interface IStockApiIntegration
    {
        Task<bool> RequestGiveOutAsync(IEnumerable<long> skus, CancellationToken token);
    }
}
