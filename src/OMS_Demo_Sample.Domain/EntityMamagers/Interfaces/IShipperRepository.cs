using OMS_Demo_Sample.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace OMS_Demo_Sample.EntityMamagers.Interfaces
{
    public interface IShipperRepository
    {
        Task<Order> GetByIdAsync(Order shipper, CancellationToken token);
        Task<Order> CreateAsync(Order shipper, CancellationToken token);
        Task<Order> UpdateAsync(Order shipper, CancellationToken token);
        Task<Order> DeleteAsync(Order shipper, CancellationToken token);
    }
}