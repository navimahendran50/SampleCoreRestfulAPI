using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleCoreRestfulAPI.Data;
using SampleCoreRestfulAPI.Dtos;
using SampleCoreRestfulAPI.Interfaces;
using SampleCoreRestfulAPI.Mappers;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Repositories
{
    public sealed class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Order> CreateOrderAsync(CreateOrderRequestDto order)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var customer = await GetCustomerById(order.CustomerId);
                if (customer == null)
                {
                    throw new ArgumentException("Customer not found");
                }
                var product = await GetProductById(order.ProductId);
                if (product == null)
                {
                    throw new ArgumentException("Product not found");
                }

                var odr = order.ToOrder();                

                await context.Orders.AddAsync(odr);

                customer.OrderId = odr.Id;

                context.Customers.Update(customer!);

                var result = await context.SaveChangesAsync();

                await transaction.CommitAsync();

                return result > 0 ? odr : throw new InvalidOperationException("Failed to create order");
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private async Task<Customer?> GetCustomerById(Guid? id)
        {
            return await context.Customers!.Include(o => o.Orders).FirstOrDefaultAsync(c => c.Id == id);
        }

        private async Task<Product?> GetProductById(Guid? id)
        {
            return await context.Products!.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}