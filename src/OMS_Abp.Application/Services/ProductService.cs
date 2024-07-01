using OMS_Abp.DTOs.Product;
using OMS_Abp.Domain.Entities;
using OMS_Abp.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using OMS_Abp.EntityMamagers;
using System.Net;

namespace OMS_Abp.Services
{
    public class ProductService : ApplicationService, IProductService
    {
        private readonly IRepository<Product, int> _productRepository;
        private readonly ProductManager _productManager;

        public ProductService(IRepository<Product, int> productRepository, ProductManager productManager)
        {
            _productRepository = productRepository;
            _productManager = productManager;
        }

        /// <summary>
        /// Get list of all products
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<List<GetProductDto>> GetProductsAsync(CancellationToken token)
        {
            var productList = (await _productRepository.GetQueryableAsync()).AsNoTracking().ToListAsync(token);

            return ObjectMapper.Map<List<Product>, List<GetProductDto>>(await productList);
        }

        /// <summary>
        /// Get Product by id
        /// </summary>
        /// <param name="id">product id</param>
        /// <param name="token">cancelation token</param>
        /// <returns>GetProductDto</returns>
        public async Task<GetProductDto> GetByIdAsync(int id, CancellationToken token)
        {
            var productById = (await _productRepository.GetQueryableAsync())
                .AsNoTracking()
                .FirstAsync(x => x.Id == id, token);

            return ObjectMapper.Map<Product, GetProductDto>(await productById);
        }

        public async Task CreateProductAsync(CreateProductDto productDto, CancellationToken token)
        {
            var product = ObjectMapper.Map<CreateProductDto, Product>(productDto);

            await _productManager.CreateAsync(product, token);

            await _productRepository.InsertAsync(product, cancellationToken: token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            await _productRepository.DeleteAsync(id, cancellationToken: token);
        }
    }
}