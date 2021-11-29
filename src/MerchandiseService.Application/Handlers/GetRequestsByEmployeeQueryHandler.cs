using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Application.Models;
using MerchandiseService.Application.Queries.GetRequestsByEmployee;
using MerchandiseService.Domain.AggregatesModels.MerchandiseRequestAggregate;

namespace MerchandiseService.Application.Handlers
{
    public class GetRequestsByEmployeeQueryHandler : IRequestHandler<GetRequestsByEmployeeQuery, GetRequestsByEmployeeResponse>
    {
        private readonly IMerchandiseRepository _merchandiseRepository;

        public GetRequestsByEmployeeQueryHandler(IMerchandiseRepository merchandiseRepository)
        {
            _merchandiseRepository = merchandiseRepository;
        }

        public async Task<GetRequestsByEmployeeResponse> Handle(GetRequestsByEmployeeQuery request, CancellationToken token)
        {
            var requests = await _merchandiseRepository
                .GetByEmployeeIdAsync(request.Id, token);

            return new GetRequestsByEmployeeResponse {
                Items = requests.Select(x => new MerchandiseRequestDataDto {
                    Status = x.Status.Name,
                    CreatedAt = x.CreatedAt,
                    Type = x.MerchPack.Type.Name,
                    GaveOutAt = x.GaveOutAt
                }).ToArray()
            };
        }
    }
}
