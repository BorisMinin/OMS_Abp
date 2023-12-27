using OMS_Demo_Sample.Entities;
using OMS_Demo_Sample.EntityMamagers.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace OMS_Demo_Sample.EntityMamagers
{
    #region Business rules definition
    // 1. Создаваемый экземпляр Product должен содержать CategoryId, который уже существует в бд
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

        public async Task<Product> CreateProduct(Product product, CancellationToken token)
        {
            // todo: first business rule
            if (await _categoryRepository.AnyAsync(x => x.Id != product.CategoryId, token))
                throw new ArgumentException($"{product.CategoryId} doesn't exists!");

            if (!await _categoryRepository.AnyAsync(x => x.Id.Equals(product.CategoryId), token))
                throw new EntityNotFoundException(typeof(Product), product.CategoryId);

            //var res = await _categoryRepository.Where(x=>x)

            await _categoryRepository.EnsureExistsAsync(x => x.Id == product.CategoryId, token);

            return product;
        }
    }
}