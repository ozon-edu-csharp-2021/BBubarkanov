using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Application.Commands;
using MerchandiseService.Application.Commands.NewMerchandiseAppeared;
using MerchandiseService.Application.Contracts;
using MerchandiseService.Domain.AggregatesModels.MerchandiseRequestAggregate;

namespace MerchandiseService.Application.Handlers
{
    public class NewMerchandiseAppearedHandler : IRequestHandler<NewMerchandiseAppearedCommand>
    {
        private readonly IMerchandiseRepository _merchandiseRepository;
        private readonly IStockApiIntegration _stockApiIntegration;

        public NewMerchandiseAppearedHandler(IMerchandiseRepository merchandiseRepository, IStockApiIntegration stockApiIntegration)
        {
            _merchandiseRepository = merchandiseRepository;
            _stockApiIntegration = stockApiIntegration;
        }

        public async Task<Unit> Handle(NewMerchandiseAppearedCommand request, CancellationToken token)
        {
            var allProcessingRequests = await _merchandiseRepository.GetAllProcessingRequests(token);
            
            allProcessingRequests = allProcessingRequests
                .Where(x => x.MerchPack.SkuCollection.Any(sku => request.SkuCollection.Contains(sku.Value)))
                .OrderBy(x => x.CreatedAt)
                .ToArray();
            
            foreach (var processingRequest in allProcessingRequests) {
                var isAvailable = await _stockApiIntegration.RequestGiveOutAsync(processingRequest.MerchPack.GetSkus(), token);

                processingRequest.GiveOut(isAvailable, DateTimeOffset.UtcNow);
            }
            return Unit.Value;
        }
    }
}
