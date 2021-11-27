using MerchandiseService.Application.Models;

namespace MerchandiseService.Application.Queries.GetRequestsByEmployee
{
    public class GetRequestsByEmployeeResponse
    {
        public MerchandiseRequestDataDto[] Items { get; set; }
    }
}
