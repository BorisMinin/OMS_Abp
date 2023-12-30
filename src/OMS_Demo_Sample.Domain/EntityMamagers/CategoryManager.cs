using OMS_Demo_Sample.Entities;
using OMS_Demo_Sample.EntityMamagers.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Services;
using Volo.Abp.Domain.Repositories;
using System;

namespace OMS_Demo_Sample.EntityMamagers
{
    #region Business rules definition
    // 1. The created and updated Category instance must not contain a CategoryName that already exists in the database
    #endregion
    public class CategoryManager : DomainService, ICategoryRepository
    {
        private readonly IRepository<Category, int> _categoryRepository;

        public CategoryManager(IRepository<Category, int> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> GetByIdAsync(Category category, CancellationToken token)
        {
            return category;
        }

        public async Task<Category> CreateAsync(Category category, CancellationToken token)
        {
            await IsDuplicateCategoryName(category.CategoryName, token);
            return category;
        }

        public async Task<Category> UpdateAsync(Category category, CancellationToken token)
        {
            await IsDuplicateCategoryName(category.CategoryName, token);
            return category;
        }

        public async Task<Category> DeleteAsync(Category category, CancellationToken token)
        {
            return category;
        }

        #region Business rules implementations
        /// <summary>
        /// Implementation of business rule №1
        /// </summary>
        private async Task IsDuplicateCategoryName(string categoryName, CancellationToken token)
        {
            if (await _categoryRepository.AnyAsync(x => x.CategoryName == categoryName, token))
                throw new ArgumentException($"{categoryName} already exists!");
        }
        #endregion
    }
}