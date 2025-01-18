using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleCoreRestfulAPI.Dtos;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(CreateOrderRequestDto order);
    }
}