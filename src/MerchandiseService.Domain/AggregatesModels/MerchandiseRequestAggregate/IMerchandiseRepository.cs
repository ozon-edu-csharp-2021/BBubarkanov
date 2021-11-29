using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregatesModels.MerchandiseRequestAggregate
{
    public interface IMerchandiseRepository : IRepository<MerchandiseRequest>
    {
        /// <summary>
        /// Create merchandise request
        /// </summary>
        Task<MerchandiseRequest> CreateAsync(MerchandiseRequest request, CancellationToken token);

        /// <summary>
        /// Update merchandise request
        /// </summary>
        Task UpdateAsync(MerchandiseRequest request, CancellationToken token);

        /// <summary>
        /// Get merchandise request by id
        /// </summary>
        Task<MerchandiseRequest> GetByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Get requests by employee email
        /// </summary>
        Task<IReadOnlyCollection<MerchandiseRequest>> GetByEmployeeIdAsync(long id, CancellationToken token);

        /// <summary>
        /// Get all requests with status 'Processing'
        /// </summary>
        Task<IReadOnlyCollection<MerchandiseRequest>> GetAllProcessingRequests(CancellationToken token);
    }
}
