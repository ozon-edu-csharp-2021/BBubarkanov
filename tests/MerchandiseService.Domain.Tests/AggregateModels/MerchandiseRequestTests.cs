using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using MerchandiseService.Domain.AggregatesModels.MerchandiseRequestAggregate;
using MerchandiseService.Domain.AggregatesModels.MerchPackAggregate;
using MerchandiseService.Domain.Exceptions;
using Xunit;

namespace MerchandiseService.Domain.Tests.AggregateModels
{
    public class MerchandiseRequestTests
    {
        private readonly Random _r = new();
        private readonly Faker<EmailHolder> _fakeEmail =  new Faker<EmailHolder>().RuleFor(x => x.Email, faker => faker.Person.Email);

        [Fact]
        public void CreateTest()
        {
            var alreadyExistRequests = Enumerable.Range(1, 10).Select(x => 
                new MerchandiseRequest(
                    x, 
                    new MerchPack(
                        _r.Next(), 
                        GetRandomMerchPackType(), 
                        GetRandomSkuCollection()), 
                    new Employee(_r.Next(), new Email(_fakeEmail.Generate().Email), ClothingSize.Parse(_r.Next(1, 7))), 
                    MerchandiseRequestStatus.Parse(x % 4 + 1), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow
            )).ToList();
            
            var merchPack = new MerchPack(_r.Next(), GetRandomMerchPackType(), GetRandomSkuCollection());
            var employee = new Employee(_r.Next(), new Email(_fakeEmail.Generate().Email), ClothingSize.Parse(_r.Next(1, 7)));
            Assert.NotNull(MerchandiseRequest.Create(merchPack, employee, alreadyExistRequests, DateTimeOffset.UtcNow));
            
            var alreadyExistRequest1 = alreadyExistRequests.First(x => x.Status != MerchandiseRequestStatus.Declined);
            Assert.Throws<MerchandiseRequestAlreadyExistException>(() => MerchandiseRequest.Create(
                alreadyExistRequest1.MerchPack, 
                alreadyExistRequest1.Employee,
                alreadyExistRequests,
                DateTimeOffset.UtcNow));
            
            var alreadyExistRequest2 = alreadyExistRequests.First(x => x.Status == MerchandiseRequestStatus.Declined);
            Assert.NotEqual(MerchandiseRequest.Create(
                alreadyExistRequest2.MerchPack, 
                alreadyExistRequest2.Employee,
                alreadyExistRequests,
                DateTimeOffset.UtcNow), alreadyExistRequest2);
        }

        [Fact]
        public void GiveOutTest()
        {
            var newRequest = new MerchandiseRequest(
                _r.Next(),
                new MerchPack(
                    _r.Next(),
                    GetRandomMerchPackType(),
                    GetRandomSkuCollection()),
                new Employee(_r.Next(), new Email(_fakeEmail.Generate().Email), ClothingSize.Parse(_r.Next(1, 7))),
                MerchandiseRequestStatus.New, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow
            );
            
            newRequest.GiveOut(false, DateTimeOffset.UtcNow);
            Assert.Equal(newRequest.Status, MerchandiseRequestStatus.Processing);
            Assert.Null(newRequest.DomainEvents);
            
            newRequest.GiveOut(true, DateTimeOffset.UtcNow);
            Assert.Equal(newRequest.Status, MerchandiseRequestStatus.Done);
            Assert.NotEmpty(newRequest.DomainEvents);

            Assert.Throws<UnableToGiveOutMerchandiseException>(() => newRequest.GiveOut(true, DateTimeOffset.UtcNow));
        }
        
        private class EmailHolder
        {
            public string Email { get; set; }
        }

        private MerchPackType GetRandomMerchPackType() => MerchPackType.Parse(new[] { 10, 20, 30, 40, 50 }[_r.Next(5)]);

        private HashSet<Sku> GetRandomSkuCollection() => Enumerable.Range(0, _r.Next(2, 6)).Select(_ => new Sku(_r.Next())).ToHashSet();
    }
}
