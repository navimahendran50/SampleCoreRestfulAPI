using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleCoreRestfulAPI.Dtos;

namespace SampleCoreRestfulAPI.Interfaces
{
    public interface IOrderService
    {
        Task<string?> CreateOrderAsync(CreateOrderRequestDto order);
    }
}