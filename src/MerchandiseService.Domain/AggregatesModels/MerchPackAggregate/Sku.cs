using System.Collections.Generic;
using MerchandiseService.Domain.Root;

namespace MerchandiseService.Domain.AggregatesModels.MerchPackAggregate
{
    public class Sku : ValueObject
    {
        public long Value { get; }

        public Sku(long value) => Value = value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
