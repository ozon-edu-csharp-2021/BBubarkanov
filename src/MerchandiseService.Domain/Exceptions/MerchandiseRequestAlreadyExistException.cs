using MerchandiseService.Domain.Root;

namespace MerchandiseService.Domain.Exceptions
{
    public class MerchandiseRequestAlreadyExistException : DomainException
    {
        public MerchandiseRequestAlreadyExistException(string message) : base(message) { }
    }
}
