using System;
using System.Collections.Generic;
using System.Linq;
using MerchandiseService.Domain.AggregatesModels.MerchPackAggregate;
using MerchandiseService.Domain.Exceptions;
using Xunit;

namespace MerchandiseService.Domain.Tests.AggregateModels
{
    public class MerchPackTests
    {
        private readonly Random _r = new();
        
        [Fact]
        public void AddToPackTest()
        {
            var merchPack = new MerchPack(
                _r.Next(),
                GetRandomMerchPackType(),
                GetRandomSkuCollection());

            var newSku = new Sku(_r.Next(100, 200));
            merchPack.AddToPack(newSku);
            Assert.Contains(newSku, merchPack.SkuCollection);
            Assert.Throws<SkusAlreadyExistException>(() => merchPack.AddToPack(newSku));
        }

        [Fact]
        public void DeleteFromPackTest()
        {
            var merchPack = new MerchPack(
                _r.Next(),
                GetRandomMerchPackType(),
                GetRandomSkuCollection());
            
            var existSku = merchPack.SkuCollection.First();
            merchPack.DeleteFromPack(existSku);
            Assert.DoesNotContain(existSku, merchPack.SkuCollection);
            Assert.Throws<SkusNotExistException>(() => merchPack.DeleteFromPack(existSku));
        }

        private MerchPackType GetRandomMerchPackType() => MerchPackType.Parse(new[] { 10, 20, 30, 40, 50 }[_r.Next(5)]);

        private HashSet<Sku> GetRandomSkuCollection() => Enumerable.Range(0, _r.Next(2, 6)).Select(x => new Sku(_r.Next(1, 100))).ToHashSet();
    }
}
