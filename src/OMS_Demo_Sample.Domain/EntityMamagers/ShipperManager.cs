using OMS_Demo_Sample.Entities;
using OMS_Demo_Sample.EntityMamagers.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace OMS_Demo_Sample.EntityMamagers
{
    public class ShipperManager : DomainService, IShipperRepository
    {
        public async Task<Order> GetByIdAsync(Order shipper, CancellationToken token)
        {
            return shipper;
        }
        public async Task<Order> CreateAsync(Order shipper, CancellationToken token)
        {
            return shipper;
        }

        public async Task<Order> UpdateAsync(Order shipper, CancellationToken token)
        {
            return shipper;
        }

        public async Task<Order> DeleteAsync(Order shipper, CancellationToken token)
        {
            return shipper;
        }
    }
}