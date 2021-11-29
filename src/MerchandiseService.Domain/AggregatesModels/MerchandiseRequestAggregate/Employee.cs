using System.Collections.Generic;
using MerchandiseService.Domain.Root;

namespace MerchandiseService.Domain.AggregatesModels.MerchandiseRequestAggregate
{
    /// <summary>
    /// Employee information
    /// </summary>
    public class Employee : ValueObject
    {
        /// <summary>
        /// Employee's id
        /// </summary>
        public long Id { get; }
        
        /// <summary>
        /// Employee's email address
        /// </summary>
        public Email Email { get; }
        
        /// <summary>
        /// Clothing size
        /// </summary>
        public ClothingSize ClothingSize { get; }

        public Employee(long id, Email email, ClothingSize clothingSize)
        {
            Id = id;
            Email = email;
            ClothingSize = clothingSize;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
