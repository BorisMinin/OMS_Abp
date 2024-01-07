using OMS_Demo_Sample.Entities;
using OMS_Demo_Sample.EntityMamagers.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace OMS_Demo_Sample.EntityMamagers
{
    #region Business rules definition
    // 1. 
    #endregion

    public class OrderDetailManager : DomainService, IOrderDetailRepository
    {
        private IRepository<OrderDetail> _orderDetailRepository;

        public OrderDetailManager(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;    
        }

        public async Task<OrderDetail> GetByIdAsync(OrderDetail orderDetail, CancellationToken token)
        {
            return orderDetail;
        }

        public async Task<OrderDetail> CreateAsync(OrderDetail orderDetail, CancellationToken token)
        {
            await IsCustomerBuyingMoreThanFiveTea(orderDetail, token);

            return orderDetail;
        }

        public async Task<OrderDetail> UpdateAsync(OrderDetail orderDetail, CancellationToken token)
        {
            return orderDetail;
        }

        public async Task<OrderDetail> DeleteAsync(OrderDetail orderDetail, CancellationToken token)
        {
            return orderDetail;
        }

        private async Task IsCustomerBuyingMoreThanFiveTea(OrderDetail orderDetail, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}