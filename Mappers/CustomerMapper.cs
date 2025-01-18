using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleCoreRestfulAPI.Dtos;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Mappers
{
    public static class CustomerMapper
    {
        public static Customer ToCustomer(this CreateCustomerRequestDto createCustomerRequestDto)
        {
            if(createCustomerRequestDto == null)
            {
                throw new ArgumentNullException(nameof(createCustomerRequestDto));
            }
            return new()
            {
                Name = createCustomerRequestDto.Name,
                DateOfBirth = createCustomerRequestDto.DateOfBirth,
                Email = createCustomerRequestDto.Email,
                Phone = createCustomerRequestDto.Phone,
                Address = createCustomerRequestDto.Address,
                City = createCustomerRequestDto.City,
                State = createCustomerRequestDto.State,
                Zip = createCustomerRequestDto.Zip
            };
        }

        public static CustomerDto ToCustomerDto(this Customer customer)    
        {
            if (customer == null)
            {
            throw new ArgumentNullException(nameof(customer));
            }
            return new()
            {
                Name = customer.Name,                         
                Orders = customer.Orders?.Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    OrderNumber = o.OrderNumber.ToString(),
                    Quantity = o.Quantity
                }).ToList()
            };
        }
    }
}