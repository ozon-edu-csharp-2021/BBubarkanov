using MerchandiseService.Domain.Root;

namespace MerchandiseService.Domain.Contracts
{
    /// <summary>
    /// Base interface of repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : Entity { }
}
