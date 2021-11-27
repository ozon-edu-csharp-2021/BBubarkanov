using System.Threading.Tasks;
using MerchandiseService.Domain.AggregatesModels.MerchandiseRequestAggregate;

namespace MerchandiseService.Application.Contracts
{
    public interface IEmailService
    {
        Task SendEmail(Email email);
    }
}
