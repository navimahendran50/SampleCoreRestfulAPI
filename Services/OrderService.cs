using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleCoreRestfulAPI.Dtos;
using SampleCoreRestfulAPI.Interfaces;

namespace SampleCoreRestfulAPI.Services
{
    public sealed class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<string?> CreateOrderAsync(CreateOrderRequestDto order)
        {
            var orderDetails = await orderRepository.CreateOrderAsync(order);
            return orderDetails?.OrderNumber.ToString();
        }
    }
}