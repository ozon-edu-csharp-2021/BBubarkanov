using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Application.Commands.GiveOutMerchandise;
using MerchandiseService.Application.Contracts;
using MerchandiseService.Domain.AggregatesModels.MerchandiseRequestAggregate;
using MerchandiseService.Domain.AggregatesModels.MerchPackAggregate;

namespace MerchandiseService.Application.Handlers
{
    public class GiveOutMerchandiseHandler : IRequestHandler<GiveOutMerchandiseCommand, GiveOutMerchandiseResponse>
    {
        private readonly IMerchandiseRepository _merchandiseRepository;
        private readonly IMerchPackRepository _merchPackRepository;
        private readonly IStockApiIntegration _stockApiIntegration;
        private readonly IEmailService _emailService;

        public GiveOutMerchandiseHandler(IMerchandiseRepository merchandiseRepository, 
            IMerchPackRepository merchPackRepository, IStockApiIntegration stockApiIntegration,
            IEmailService emailService)
        {
            _merchandiseRepository = merchandiseRepository;
            _merchPackRepository = merchPackRepository;
            _stockApiIntegration = stockApiIntegration;
            _emailService = emailService;
        }

        public async Task<GiveOutMerchandiseResponse> Handle(GiveOutMerchandiseCommand request, CancellationToken token)
        {
            var pack = await _merchPackRepository.GetByTypeAsync(MerchPackType.Parse(request.MerchPackType), token);
            
            var alreadyExistRequests = await _merchandiseRepository
                .GetByEmployeeIdAsync(request.EmployeeId, token);

            var newMerchandiseRequest = MerchandiseRequest.Create(
                pack, new Employee(request.EmployeeId, new Email(request.EmployeeEmail), 
                    ClothingSize.Parse(request.EmployeeClothingSize)),
                alreadyExistRequests,
                DateTimeOffset.UtcNow);

            var createdMerchandiseRequest = await _merchandiseRepository.CreateAsync(newMerchandiseRequest, token);

            var isMerchPackAvailable =
                await _stockApiIntegration.RequestGiveOutAsync(pack.SkuCollection.Select(x => x.Value), token);
            
            createdMerchandiseRequest.GiveOut(isMerchPackAvailable, DateTimeOffset.UtcNow);

            await _emailService.SendEmail(createdMerchandiseRequest.Employee.Email);

            return new GiveOutMerchandiseResponse {
                Status = createdMerchandiseRequest.Status
            };
        }
    }
}
