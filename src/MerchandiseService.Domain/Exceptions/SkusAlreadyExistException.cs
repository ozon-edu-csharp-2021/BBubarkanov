using MerchandiseService.Domain.Root;

namespace MerchandiseService.Domain.Exceptions
{
    public class SkusAlreadyExistException : DomainException
    {
        public SkusAlreadyExistException(string message) : base(message) { }
    }
}
