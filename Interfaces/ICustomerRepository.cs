using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> CreateCustomerAsync(Customer customer);
        Task<Customer?> GetCustomerByIdAsync(Guid? id);
    }
}