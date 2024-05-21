using OMS_Abp.DTOs.Product;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace OMS_Abp.Interfaces
{
    public interface IProductService : IApplicationService
    {
        public Task<List<GetProductDto>> GetProductsAsync(CancellationToken token);
    }
}