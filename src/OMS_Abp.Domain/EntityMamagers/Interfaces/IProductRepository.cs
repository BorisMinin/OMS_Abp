using OMS_Abp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OMS_Abp.EntityMamagers.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Product product, CancellationToken token);
        Task<Product> CreateAsync(Product product, CancellationToken token);
        Task<Product> UpdateAsync(Product product, CancellationToken token);
        Task<Product> DeleteAsync(Product product, CancellationToken token);
    }
}