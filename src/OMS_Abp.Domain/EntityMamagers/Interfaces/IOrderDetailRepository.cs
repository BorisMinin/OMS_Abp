using OMS_Abp.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OMS_Abp.EntityMamagers.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> CreateAsync(OrderDetail orderDetail, CancellationToken token);
    }
}