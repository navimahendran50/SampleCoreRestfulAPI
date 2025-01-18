using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCoreRestfulAPI.Dtos
{
    public class CreateProductRequestDto
    {
        [Required (ErrorMessage = "Name is required")]
        [MaxLength(100)]
        public string Name { get; set; } = default!;      
         
        [Required (ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
    }
}