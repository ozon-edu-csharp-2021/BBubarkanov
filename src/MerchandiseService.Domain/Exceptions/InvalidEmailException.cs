using MerchandiseService.Domain.Root;

namespace MerchandiseService.Domain.Exceptions
{
    public class InvalidEmailException : DomainException
    {
        public InvalidEmailException(string message) : base(message) { }
    }
}