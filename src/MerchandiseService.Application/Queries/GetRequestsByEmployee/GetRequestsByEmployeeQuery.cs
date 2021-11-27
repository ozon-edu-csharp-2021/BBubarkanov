using MediatR;

namespace MerchandiseService.Application.Queries.GetRequestsByEmployee
{
    public record GetRequestsByEmployeeQuery : IRequest<GetRequestsByEmployeeResponse>
    {
        public long Id { get; set; }
    }
}
