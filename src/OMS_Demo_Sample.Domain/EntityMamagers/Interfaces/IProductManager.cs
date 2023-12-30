using OMS_Demo_Sample.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OMS_Demo_Sample.EntityMamagers.Interfaces
{
    public interface IProductManager
    {
        Task<Product> GetByIdAsync(Product product, CancellationToken token);
        Task<Product> CreateAsync(Product product, CancellationToken token);
        Task<Product> UpdateAsync(Product product, CancellationToken token);
        Task<Product> DeleteAsync(Product product, CancellationToken token);
    }
}