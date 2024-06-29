using OMS_Abp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OMS_Abp.EntityMamagers.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> CreateAsync(OrderDetail orderDetail, CancellationToken token);
    }
}