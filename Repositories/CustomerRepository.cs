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
    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<CustomerRepository> logger;
        public CustomerRepository(AppDbContext context, ILogger<CustomerRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public async Task<Customer?> CreateCustomerAsync(Customer customer)
        {
            try
            {
                await context.Customers.AddAsync(customer);
                return await context.SaveChangesAsync() > 0 ? customer : default!;                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error creating customer");
                return null;
            }
        }

        public async Task<Customer?> GetCustomerByIdAsync(Guid? id)
        {
            return await context.Customers.Include(o => o.Orders!).ThenInclude(p => p.Products).FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}