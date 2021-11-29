namespace MerchandiseService.Api.Models
{
    public record MerchRequestInputModel
    {
        public string MerchType { get; set; }
        public long EmployeeId { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeClothingSize { get; set; }
    }
}
