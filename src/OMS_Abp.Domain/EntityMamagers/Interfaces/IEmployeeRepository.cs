using OMS_Abp.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace OMS_Abp.EntityMamagers.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(Employee employee, CancellationToken token);
        Task<Employee> CreateAsync(Employee employee, CancellationToken token);
        Task<Employee> UpdateAsync(Employee employee, CancellationToken token);
        Task<Employee> DeleteAsync(Employee employee, CancellationToken token);
    }
}