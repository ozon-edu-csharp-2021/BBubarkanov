using System.Collections.Generic;
using System.Linq;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Root;

namespace MerchandiseService.Domain.AggregatesModels.MerchPackAggregate
{
    public sealed class MerchPack : Entity
    {
        private readonly ISet<Sku> _skuCollection;
        public IReadOnlyCollection<Sku> SkuCollection => _skuCollection.ToArray();

        public MerchPackType Type { get; }
        
        public MerchPack(long id, MerchPackType type, ISet<Sku> skuCollection)
        {
            Id = id;
            Type = type;
            _skuCollection = skuCollection;
        }

        /// <summary>
        /// Adds skus to SkuCollection
        /// </summary>
        /// <param name="skus">skus to add</param>
        /// <exception cref="SkusAlreadyExistException">some or all skus already exist</exception>
        public void AddToPack(params Sku[] skus)
        {
            var intersect = _skuCollection.Intersect(skus)
                .Select(x => x.Value)
                .ToArray();
            
            if (intersect.Length > 0) {
                throw new SkusAlreadyExistException($"Sku with ids {string.Join(", ", intersect)} already exist");
            }

            _skuCollection.UnionWith(skus);
        }

        /// <summary>
        /// Deletes skus from SkuCollection
        /// </summary>
        /// <param name="skus">skus to delete</param>
        /// <exception cref="SkusNotExistException">some or all skus not exist</exception>
        public void DeleteFromPack(params Sku[] skus)
        {
            var except = skus.Except(_skuCollection)
                .Select(x => x.Value)
                .ToArray();
            
            if (except.Length > 0) {
                throw new SkusNotExistException($"Sku with ids {string.Join(", ", except)} not exist");
            }

            _skuCollection.ExceptWith(skus);
        }

        public IReadOnlyCollection<long> GetSkus() => _skuCollection.Select(x => x.Value).ToArray();
    }
}
