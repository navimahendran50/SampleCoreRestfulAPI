using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleCoreRestfulAPI.Data;
using SampleCoreRestfulAPI.Interfaces;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;
        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Product?> CreateProductAsync(Product product)
        {
            await context.Products.AddAsync(product);
            return await context.SaveChangesAsync() > 0 ? product : default!;
        }

        public async Task<Product?> GetProductAsync(Guid id)
        {
            return await context.Products!.FindAsync(id);
        }

        public async Task<IEnumerable<Product?>> GetProductsAsync()
        {
            return await context.Products!.ToListAsync();
        }
    }
}