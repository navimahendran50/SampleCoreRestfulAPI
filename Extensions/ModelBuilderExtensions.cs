using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder Relationships(this ModelBuilder  modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);
            return modelBuilder;
        }
    }
}