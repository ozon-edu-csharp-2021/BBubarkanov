using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregatesModels.MerchPackAggregate
{
    public interface IMerchPackRepository : IRepository<MerchPack>
    {
        /// <summary>
        /// Save merch pack
        /// </summary>
        Task SaveAsync(MerchPack merchPack, CancellationToken token);
        
        /// <summary>
        /// Get merch pack by id
        /// </summary>
        Task<MerchPack> GetByIdAsync(long id, CancellationToken token);

        /// <summary>
        /// Get merch pack by type
        /// </summary>
        Task<MerchPack> GetByTypeAsync(MerchPackType type, CancellationToken token);
    }
}
