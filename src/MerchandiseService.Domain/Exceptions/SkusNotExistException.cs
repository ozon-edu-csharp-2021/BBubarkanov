using MerchandiseService.Domain.Root;

namespace MerchandiseService.Domain.Exceptions
{
    public class SkusNotExistException : DomainException
    {
        public SkusNotExistException(string message) : base(message) { }
    }
}
