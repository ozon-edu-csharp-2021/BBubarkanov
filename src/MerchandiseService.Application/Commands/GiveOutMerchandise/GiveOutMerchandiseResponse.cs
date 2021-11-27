using MerchandiseService.Domain.AggregatesModels.MerchandiseRequestAggregate;

namespace MerchandiseService.Application.Commands.GiveOutMerchandise
{
    public record GiveOutMerchandiseResponse
    {
        public MerchandiseRequestStatus Status { get; set; }
    }
}
