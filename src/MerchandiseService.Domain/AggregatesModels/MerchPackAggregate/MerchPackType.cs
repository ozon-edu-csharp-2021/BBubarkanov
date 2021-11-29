using MerchandiseService.Domain.Root;

namespace MerchandiseService.Domain.AggregatesModels.MerchPackAggregate
{
    public class MerchPackType : Enumeration<MerchPackType>
    {
        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при устройстве на работу.
        /// </summary>
        public static MerchPackType WelcomePack = new(10, nameof(WelcomePack));
        
        /// /// <summary>
        /// Набор мерча, выдаваемый сотруднику при посещении конференции в качестве слушателя.
        /// </summary>
        public static MerchPackType ConferenceListenerPack = new(20, nameof(ConferenceListenerPack));
        
        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при посещении конференции в качестве спикера.
        /// </summary>
        public static MerchPackType ConferenceSpeakerPack = new(30, nameof(ConferenceSpeakerPack));
        
        /// /// <summary>
        /// Набор мерча, выдаваемый сотруднику при успешном прохождении испытательного срока.
        /// </summary>
        public static MerchPackType ProbationPeriodEndingPack = new(40, nameof(ProbationPeriodEndingPack));
        
        /// <summary>
        /// Набор мерча, выдаваемый сотруднику за выслугу лет.
        /// </summary>
        public static MerchPackType VeteranPack = new(50, nameof(VeteranPack));
        
        public MerchPackType(int id, string name) : base(id, name) { }
    }
}
