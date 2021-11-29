using System.Collections.Generic;
using System.Net.Mail;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Root;

namespace MerchandiseService.Domain.AggregatesModels.MerchandiseRequestAggregate
{
    public class Email : ValueObject
    {
        public string Value { get; }
     
        public Email(string value)
        {
            if (!IsValidEmail(value))
                throw new InvalidEmailException($"Email is invalid: {value}");
            
            Value = value;
        }

        /// <inheritdoc/>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;

        private static bool IsValidEmail(string email)
            => MailAddress.TryCreate(email, out _);
    }
}
