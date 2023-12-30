using OMS_Demo_Sample.Entities;
using OMS_Demo_Sample.EntityMamagers.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace OMS_Demo_Sample.EntityMamagers
{
    #region Business rules definition
    // 1. The created and updated Product instance must contain the CategoryId that already exists in the database
    // 2. The created and updated Product instance must not contain the CategoryName that already exists in the database
    #endregion

    public class ProductManager : DomainService, IProductManager
    {
        private readonly IRepository<Product, int> _productRepository;
        private readonly IRepository<Category, int> _categoryRepository;

        public ProductManager(IRepository<Product, int> productRepository,
            IRepository<Category, int> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Product> GetByIdAsync(Product product, CancellationToken token)
        {
            return product;
        }

        public async Task<Product> CreateAsync(Product product, CancellationToken token)
        {
            // Implementation of business rule №1    
            await _categoryRepository.EnsureExistsAsync(x => x.Id == product.CategoryId, token);
            await IsDuplicateProductName(product.ProductName, token);

            return product;
        }

        public async Task<Product> UpdateAsync(Product product, CancellationToken token)
        {
            // Implementation of business rule №1    
            await _categoryRepository.EnsureExistsAsync(x => x.Id == product.CategoryId, token);
            await IsDuplicateProductName(product.ProductName, token);

            return product;
        }

        public async Task<Product> DeleteAsync(Product product, CancellationToken token)
        {
            return product;
        }

        #region Business rules implementations
        /// <summary>
        /// Implementation of business rule №2
        /// </summary>
        private async Task IsDuplicateProductName(string productName, CancellationToken token)
        {
            if (await _productRepository.AnyAsync(x => x.ProductName == productName, token))
                throw new ArgumentException($"{productName} already exists!");
        }
        #endregion
    }
}