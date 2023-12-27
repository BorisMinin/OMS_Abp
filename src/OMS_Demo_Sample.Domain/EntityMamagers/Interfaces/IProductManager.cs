using OMS_Demo_Sample.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OMS_Demo_Sample.EntityMamagers.Interfaces
{
    public interface IProductManager
    {
        Task<Product> CreateProduct(Product product, CancellationToken token);
    }
}