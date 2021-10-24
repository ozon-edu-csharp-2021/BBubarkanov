using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MerchandiseService.Grpc;

namespace MerchandiseService.Api.GrpcServices
{
    public class MerchGrpcService : MerchGrpc.MerchGrpcBase
    {
        public override Task<Merch> GetMerch(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new Merch());
        }

        public override Task<MerchInfo> GetMerchInfo(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new MerchInfo());
        }
    }
}
