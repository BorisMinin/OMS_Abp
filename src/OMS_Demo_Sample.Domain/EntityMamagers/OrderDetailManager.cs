using OMS_Demo_Sample.Entities;
using OMS_Demo_Sample.EntityMamagers.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace OMS_Demo_Sample.EntityMamagers
{
    #region Business rules definition
    // 1. Getting, updating and deleting records from the OrderDetail table is prohibited.
    // 2. Adding Product to OrderDetail is possible only in an amount not exceeding the number of products in stock.
    #endregion

    public class OrderDetailManager : DomainService, IOrderDetailRepository
    {
        private IRepository<Product> _productRepository;

        public OrderDetailManager(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<OrderDetail> CreateAsync(OrderDetail orderDetail, CancellationToken token)
        {
            await QuantityInStock(orderDetail.ProductId, orderDetail.Quantity, token);

            return orderDetail;
        }

        #region Business rules implementations
        /// <summary>
        /// Implementation of business rule №2
        /// </summary>
        private async Task QuantityInStock(int productId, int quantity, CancellationToken token)
        {
            var productsInStock = (await _productRepository.GetQueryableAsync())
                .Where(x=> x.Id == productId).Count();             

            if (quantity > productsInStock)
                throw new Exception("The quantity exceeds the available stock.");
        }
        #endregion
    }
}