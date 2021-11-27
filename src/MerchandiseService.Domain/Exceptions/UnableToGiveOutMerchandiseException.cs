using MerchandiseService.Domain.Root;

namespace MerchandiseService.Domain.Exceptions
{
    public class UnableToGiveOutMerchandiseException : DomainException
    {
        public UnableToGiveOutMerchandiseException(string message) : base(message) { }
    }
}
