using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCoreRestfulAPI.Dtos
{
    public class CreateOrderRequestDto
    {
        [Required (ErrorMessage = "Please provide a customer id")]
        public Guid CustomerId { get; set; }
        [Required (ErrorMessage = "Please provide a product id")]
        public Guid ProductId { get; set; }
        [Required (ErrorMessage = "Please provide a quantity")]
        public int Quantity { get; set; }
    }
}