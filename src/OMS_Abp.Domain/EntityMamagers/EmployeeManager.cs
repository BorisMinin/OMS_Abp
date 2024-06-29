using OMS_Abp.Domain.Entities;
using OMS_Abp.EntityMamagers.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace OMS_Abp.EntityMamagers
{
    public class EmployeeManager : DomainService, IEmployeeRepository
    {
        public async Task<Employee> GetByIdAsync(Employee employee, CancellationToken token)
        {
            return employee;
        }

        public async Task<Employee> CreateAsync(Employee employee, CancellationToken token)
        {
            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee employee, CancellationToken token)
        {
            return employee;
        }

        public async Task<Employee> DeleteAsync(Employee employee, CancellationToken token)
        {
            return employee;
        }
    }
}