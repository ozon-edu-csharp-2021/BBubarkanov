using MediatR;
using MerchandiseService.Domain.AggregatesModels.MerchPackAggregate;

namespace MerchandiseService.Domain.AggregatesModels.MerchandiseRequestAggregate.DomainEvents
{
    public record MerchandiseRequestGaveOut : INotification
    {
        public MerchPack MerchPack { get; init; }
        public Employee Employee { get; init; }
    }
}
