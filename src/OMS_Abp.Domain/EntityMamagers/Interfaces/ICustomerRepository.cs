using OMS_Abp.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace OMS_Abp.EntityMamagers.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(Customer customer, CancellationToken token);
        Task<Customer> CreateAsync(Customer customer, CancellationToken token);
        Task<Customer> UpdateAsync(Customer customer, CancellationToken token);
        Task<Customer> DeleteAsync(Customer customer, CancellationToken token);
    }
}