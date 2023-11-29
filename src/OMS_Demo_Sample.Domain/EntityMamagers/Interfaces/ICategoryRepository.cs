using OMS_Demo_Sample.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OMS_Demo_Sample.EntityMamagers.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category category, CancellationToken token);
        Task<Category> DeleteAsync (Category category, CancellationToken token);
    }
}