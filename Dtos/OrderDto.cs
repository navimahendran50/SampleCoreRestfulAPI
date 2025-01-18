using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; } = default!;
        public int Quantity { get; set; }
        public Product? Product { get; set; }
    }
}