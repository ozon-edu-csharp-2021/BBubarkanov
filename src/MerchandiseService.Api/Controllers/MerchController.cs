using System;
using System.Threading.Tasks;
using MerchandiseService.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/merch")]
    public class MerchController : ControllerBase
    {
        [HttpGet]
        public Task<ActionResult<MerchResponse>> Get(MerchRequest request) 
            => throw new NotImplementedException();

        [HttpGet("info")]
        public Task<ActionResult<MerchInfoResponse>> Info(MerchInfoRequest request) 
            => throw new NotImplementedException();
    }
}
