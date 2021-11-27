using System.Collections.Generic;
using MediatR;

namespace MerchandiseService.Application.Commands.NewMerchandiseAppeared
{
    public record NewMerchandiseAppearedCommand : IRequest
    {
        public IReadOnlyCollection<long> SkuCollection { get; init; }
    }
}
