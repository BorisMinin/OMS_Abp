using OMS_Abp.Entities;
using OMS_Abp.EntityMamagers.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace OMS_Abp.EntityMamagers
{
    public class CustomerManager : DomainService, ICustomerRepository
    {      
        public async Task<Customer> GetByIdAsync(Customer customer, CancellationToken token)
        {
            return customer;
        }

        public async Task<Customer> CreateAsync(Customer customer, CancellationToken token)
        {
            return customer;
        }
      
        public async Task<Customer> UpdateAsync(Customer customer, CancellationToken token)
        {
            return customer;
        }

        public async Task<Customer> DeleteAsync(Customer customer, CancellationToken token)
        {
            return customer;
        }
    }
}