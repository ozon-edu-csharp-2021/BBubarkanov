using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Api.Models;

namespace MerchandiseService.HttpClient
{
    public class MerchandiseHttpClient: IMerchandiseHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;
        
        public MerchandiseHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RequestStatusOutputModel> GetMerch(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("api/v1/merch", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<RequestStatusOutputModel>(body);
        }

        public async Task<EmployeeRequestsOutputModel> GetMerchInfo(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("api/v1/merch/info", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<EmployeeRequestsOutputModel>(body);
        }
    }
}
