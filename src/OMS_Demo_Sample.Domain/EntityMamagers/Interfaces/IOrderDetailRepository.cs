using OMS_Demo_Sample.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OMS_Demo_Sample.EntityMamagers.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> CreateAsync(OrderDetail orderDetail, CancellationToken token);
    }
}