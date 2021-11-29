using System;

namespace MerchandiseService.Domain.Root
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
