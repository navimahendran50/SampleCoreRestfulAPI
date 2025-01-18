using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleCoreRestfulAPI.Extensions;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {               
        public virtual DbSet<Product> Products { get; set; } = default!;
        public virtual DbSet<Order> Orders { get; set; } = default!;
        public virtual DbSet<Customer> Customers { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Relationships();
            base.OnModelCreating(builder);
        }
    }   
}