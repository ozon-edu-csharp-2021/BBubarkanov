using MerchandiseService.Application.Models;

namespace MerchandiseService.Api.Models
{
    public record EmployeeRequestsOutputModel
    {
        public MerchandiseRequestDataDto[] Items { get; set; }
    };
}
