using System;
using System.Collections.Generic;
using System.Linq;
using MerchandiseService.Domain.AggregatesModels.MerchandiseRequestAggregate.DomainEvents;
using MerchandiseService.Domain.AggregatesModels.MerchPackAggregate;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Root;

namespace MerchandiseService.Domain.AggregatesModels.MerchandiseRequestAggregate
{
    public sealed class MerchandiseRequest : Entity, IAggregateRoot
    {
        /// <summary>
        /// Merch pack id
        /// </summary>
        public MerchPack MerchPack { get; }

        /// <summary>
        /// Employee information
        /// </summary>
        public Employee Employee { get; }

        /// <summary>
        /// Request status
        /// </summary>
        public MerchandiseRequestStatus Status { get; private set; }

        /// <summary>
        /// Date of the request
        /// </summary>
        public DateTimeOffset CreatedAt { get; private set; }

        /// <summary>
        /// Date of issue of merchandise
        /// </summary>
        public DateTimeOffset? GaveOutAt { get; private set; }

        public MerchandiseRequest(long id, MerchPack merchPack, Employee employee, 
            MerchandiseRequestStatus merchandiseRequestStatus, DateTimeOffset createdAt, DateTimeOffset? gaveOutAt)
        {
            Id = id;
            MerchPack = merchPack;
            Employee = employee;
            Status = merchandiseRequestStatus;
            CreatedAt = createdAt;
            GaveOutAt = gaveOutAt;
        }

        private MerchandiseRequest(MerchPack merchPack, Employee employee, DateTimeOffset createdAt)
        {
            MerchPack = merchPack;
            Employee = employee;
            CreatedAt = createdAt;
            Status = MerchandiseRequestStatus.New;
        }

        public static MerchandiseRequest Create(MerchPack merchPack, Employee employee,
            IReadOnlyCollection<MerchandiseRequest> alreadyExistRequests, DateTimeOffset createdAt)
        {
            MerchandiseRequest newRequest = new(merchPack, employee, createdAt);

            if (!newRequest.CheckAbilityToGiveOut(alreadyExistRequests)) {
                throw new MerchandiseRequestAlreadyExistException("Merchandise is unable to give out");
            }
            
            return newRequest;
        }

        /// <summary>
        /// Give out merchandise
        /// </summary>
        /// <param name="isAvailable"></param>
        /// <param name="gaveOutAt"></param>
        /// <exception cref="UnableToGiveOutMerchandiseException"></exception>
        public void GiveOut(bool isAvailable, DateTimeOffset gaveOutAt)
        {
            if (Status != MerchandiseRequestStatus.New && Status != MerchandiseRequestStatus.Processing)
                throw new UnableToGiveOutMerchandiseException($"Unable to give out merchandise for request in '{Status}' status");
            
            if (!isAvailable)
                Status = MerchandiseRequestStatus.Processing;
            else {
                Status = MerchandiseRequestStatus.Done;
                GaveOutAt = gaveOutAt;
                    
                AddDomainEvent(new MerchandiseRequestGaveOut {
                    MerchPack = MerchPack,
                    Employee = Employee
                });
            }
        }

        private bool CheckAbilityToGiveOut(IReadOnlyCollection<MerchandiseRequest> alreadyExistRequests)
        {
            return !alreadyExistRequests
                .Any(x => 
                    x.Status != MerchandiseRequestStatus.Declined && 
                    x.Employee == Employee && 
                    x.MerchPack.Id == MerchPack.Id);
        }
    }
}
