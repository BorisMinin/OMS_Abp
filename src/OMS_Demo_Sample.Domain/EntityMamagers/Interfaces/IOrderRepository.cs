using OMS_Demo_Sample.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OMS_Demo_Sample.EntityMamagers.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Order order, CancellationToken token);
        Task<Order> CreateAsync(Order order, CancellationToken token);
        Task<Order> UpdateAsync(Order order, CancellationToken token);
        Task<Order> DeleteAsync(Order order, CancellationToken token);
    }
}