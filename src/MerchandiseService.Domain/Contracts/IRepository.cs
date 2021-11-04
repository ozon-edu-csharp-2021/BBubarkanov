using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.Contracts
{
    /// <summary>
    /// Базовый интерфейс репозитория
    /// </summary>
    /// <typeparam name="T">Объект сущности для управления</typeparam>
    public interface IRepository<T> where T : IAggregateRoot
    {
        /// <summary>
        /// Объект <see cref="IUnitOfWork"/>
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
    }
}
