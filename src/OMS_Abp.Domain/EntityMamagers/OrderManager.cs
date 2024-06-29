using OMS_Abp.Domain.Entities;
using OMS_Abp.EntityMamagers.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace OMS_Abp.EntityMamagers
{
    #region Business rules definition
    // 1. The created and updated Order instance must contain the CustomerId that already exists in the database
    #endregion

    public class OrderManager : DomainService, IOrderRepository
    {
        private readonly IRepository<Customer, string> _customerRepository;

        public OrderManager(IRepository<Customer, string> customerRepository)
        {
            _customerRepository = customerRepository;
        }
  
        public async Task<Order> GetByIdAsync(Order order, CancellationToken token)
        {
            return order;
        }

        public async Task<Order> CreateAsync(Order order, CancellationToken token)
        {
            // Implementation of business rule №1    
            await _customerRepository.EnsureExistsAsync(x => x.Id == order.CustomerId, token);

            return order;
        }
     
        public async Task<Order> UpdateAsync(Order order, CancellationToken token)
        {
            // Implementation of business rule №1    
            await _customerRepository.EnsureExistsAsync(x => x.Id == order.CustomerId, token);

            return order;
        }

        public async Task<Order> DeleteAsync(Order order, CancellationToken token)
        {
            return order;
        }
    }
}