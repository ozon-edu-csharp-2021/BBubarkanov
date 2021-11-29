using MerchandiseService.Domain.Root;

namespace MerchandiseService.Domain.AggregatesModels.MerchandiseRequestAggregate
{
    public class MerchandiseRequestStatus : Enumeration<MerchandiseRequestStatus>
    {
        /// <summary>
        /// New request
        /// </summary>
        public static MerchandiseRequestStatus New = new(1, nameof(New));
        
        /// <summary>
        /// Request processing
        /// </summary>
        public static MerchandiseRequestStatus Processing = new(2, nameof(Processing));
        
        /// <summary>
        /// Request processed
        /// </summary>
        public static MerchandiseRequestStatus Done = new(3, nameof(Done));
        
        /// <summary>
        /// Request declined
        /// </summary>
        public static MerchandiseRequestStatus Declined = new(4, nameof(Declined));
        
        public MerchandiseRequestStatus(int id, string name) : base(id, name) { }
    }
}
