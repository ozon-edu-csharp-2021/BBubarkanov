using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Api.Models;
using MerchandiseService.Application.Commands.GiveOutMerchandise;
using MerchandiseService.Application.Queries.GetRequestsByEmployee;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/merch")]
    public class MerchController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public MerchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<RequestStatusOutputModel>> GiveOutMerchandise(MerchRequestInputModel requestInputModel)
        {
            var response = await _mediator.Send(new GiveOutMerchandiseCommand {
                EmployeeId = requestInputModel.EmployeeId,
                EmployeeEmail = requestInputModel.EmployeeEmail,
                EmployeeClothingSize = requestInputModel.EmployeeClothingSize,
                MerchPackType = requestInputModel.MerchType
            });
            return new RequestStatusOutputModel {
                MerchandiseRequestStatus = response.Status.Name,
                MerchandiseRequestStatusCode = response.Status.Id,
            };
        }

        [HttpGet("info")]
        public async Task<ActionResult<EmployeeRequestsOutputModel>> GetRequestsByEmployee(EmployeeRequestsInputModel request)
        {
            var requests = await _mediator.Send(new GetRequestsByEmployeeQuery {
                Id = request.Id
            });
            return new EmployeeRequestsOutputModel {
                Items = requests.Items
            };
        }
    }
}
