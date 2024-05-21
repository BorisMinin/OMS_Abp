using OMS_Abp.DTOs.Product;
using OMS_Abp.Entities;
using OMS_Abp.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace OMS_Abp.Services
{
    public class ProductService : ApplicationService, IProductService
    {
        private readonly IRepository<Product, int> _productRepository;

        public ProductService(IRepository<Product, int> productRepository)
        {
            _productRepository = productRepository;  
        }

        /// <summary>
        /// Get list of all products
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<List<GetProductDto>> GetProductsAsync(CancellationToken token)
        {
            var productList = await _productRepository.GetListAsync();

            return ObjectMapper.Map<List<Product>, List<GetProductDto>> (productList);
        }
    }
}