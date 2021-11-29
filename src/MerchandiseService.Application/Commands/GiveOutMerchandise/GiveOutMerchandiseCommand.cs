using MediatR;

namespace MerchandiseService.Application.Commands.GiveOutMerchandise
{
    public record GiveOutMerchandiseCommand : IRequest<GiveOutMerchandiseResponse>
    {
        public long EmployeeId { get; set; }
        
        public string EmployeeEmail { get; init; }
        
        public string EmployeeClothingSize { get; init; }
        
        public string MerchPackType { get; init; }
    }
}
