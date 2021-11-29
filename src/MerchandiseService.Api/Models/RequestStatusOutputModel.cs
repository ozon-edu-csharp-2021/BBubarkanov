namespace MerchandiseService.Api.Models
{
    public record RequestStatusOutputModel
    {
        public int MerchandiseRequestStatusCode { get; set; }
        public string MerchandiseRequestStatus { get; set; }
    }
}
