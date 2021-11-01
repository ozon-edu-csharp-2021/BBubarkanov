using System.Threading.Tasks;
using Grpc.Core;
using MerchandiseService.Grpc;

namespace MerchandiseService.Api.GrpcServices
{
    public class MerchGrpcService : MerchGrpc.MerchGrpcBase
    {
        public override Task<MerchResponse> GetMerch(MerchRequest request, ServerCallContext context)
        {
            return Task.FromResult(new MerchResponse());
        }

        public override Task<MerchInfoResponse> GetMerchInfo(MerchInfoRequest request, ServerCallContext context)
        {
            return Task.FromResult(new MerchInfoResponse());
        }
    }
}
