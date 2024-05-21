using OMS_Abp.DTOs.Category;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace OMS_Abp.Interfaces
{
    public interface ICategoryService : IApplicationService
    {
        public Task<List<GetCategoryDto>> GetCategoriesAsync(CancellationToken token);

        public Task<GetCategoryDto> GetCategoryByIdAsync(int id, CancellationToken token);
    }
}