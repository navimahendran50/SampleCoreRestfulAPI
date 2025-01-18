using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SampleCoreRestfulAPI.Dtos;
using SampleCoreRestfulAPI.Interfaces;
using SampleCoreRestfulAPI.Mappers;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<Product?> CreateProductAsync(CreateProductRequestDto product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            return await productRepository.CreateProductAsync(product.ToProduct());
        }

        public async Task<Product?> GetProductAsync(Guid id)
        {
            if(id == Guid.Empty)
            {
            throw new ArgumentNullException(nameof(id));
            }   
            var product = await productRepository.GetProductAsync(id);
            return product ?? new Product(); 
        }

        public async Task<IEnumerable<Product?>> GetProductsAsync()
        {
            var products = await productRepository.GetProductsAsync();
            return products.Any() ? products : Enumerable.Empty<Product?>();
        }
    }
}