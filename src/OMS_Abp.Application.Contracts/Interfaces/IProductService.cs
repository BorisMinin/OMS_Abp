﻿using OMS_Abp.DTOs.Product;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace OMS_Abp.Interfaces
{
    public interface IProductService : IApplicationService
    {
        public Task<List<GetProductDto>> GetProductsAsync(CancellationToken token);
        public Task<GetProductDto> GetByIdAsync(int id, CancellationToken token);
        public Task CreateProductAsync(CreateProductDto productDto, CancellationToken token);
        public Task DeleteAsync(int id, CancellationToken token);
    }
}