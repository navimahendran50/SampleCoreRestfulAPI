using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCoreRestfulAPI.Dtos
{
    public class CreateCustomerRequestDto
    {
        [Required]
        [MaxLength(50)] 
        public string Name { get; set; } = default!;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(50)]
        public string? Email { get; set; } 
        [Required]
        [MaxLength(10)] 
        public string Phone { get; set; } = default!;
        [Required]
        [MaxLength(50)] 
        public string Address { get; set; } = default!;
        [Required]
        [MaxLength(15)] 
        public string City { get; set; } = default!;
        [Required]
        [MaxLength(15)] 
        public string State { get; set; } = default!;
        [Required]  
        [MaxLength(6)] 
        public string Zip { get; set; } = default!;
    }
}