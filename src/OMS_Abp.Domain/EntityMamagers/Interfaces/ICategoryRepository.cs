using OMS_Abp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OMS_Abp.EntityMamagers.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(Category category, CancellationToken token);
        Task<Category> CreateAsync(Category category, CancellationToken token);
        Task<Category> UpdateAsync(Category category, CancellationToken token);
        Task<Category> DeleteAsync(Category category, CancellationToken token);
    }
}