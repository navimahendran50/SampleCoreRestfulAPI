using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleCoreRestfulAPI.Models;

namespace SampleCoreRestfulAPI.Dtos
{
    public class CustomerDto
    {        
        public string? Name { get; set; }        
        public List<OrderDto>? Orders { get; set; }
    }
}