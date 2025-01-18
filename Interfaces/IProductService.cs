using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleCoreRestfulAPI.Dtos;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product?>> GetProductsAsync();
        Task<Product?> GetProductAsync(Guid id);
        Task<Product?> CreateProductAsync(CreateProductRequestDto product);
    }
}