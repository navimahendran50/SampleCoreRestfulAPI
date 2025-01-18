using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleCoreRestfulAPI.Dtos;
using SampleCoreRestfulAPI.Interfaces;
using SampleCoreRestfulAPI.Mappers;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task<Customer?> CreateCustomerAsync(CreateCustomerRequestDto customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            return await customerRepository.CreateCustomerAsync(customer.ToCustomer()) ?? new Customer();
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(Guid? id)
        {
            var customer = await customerRepository.GetCustomerByIdAsync(id);
            return customer?.ToCustomerDto();
        }
    }
}