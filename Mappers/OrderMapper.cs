using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleCoreRestfulAPI.Dtos;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Mappers
{
    public static class OrderMapper
    {
        public static Order ToOrder(this CreateOrderRequestDto order)
        {
            return new Order
            {
                CustomerId = order.CustomerId,
                ProductId = order.ProductId,
                Quantity = order.Quantity
            };
        }
    }
}