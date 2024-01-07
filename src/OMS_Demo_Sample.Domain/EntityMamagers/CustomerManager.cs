using OMS_Demo_Sample.Entities;
using OMS_Demo_Sample.EntityMamagers.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace OMS_Demo_Sample.EntityMamagers
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