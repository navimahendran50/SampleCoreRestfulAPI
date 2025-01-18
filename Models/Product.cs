using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCoreRestfulAPI.Models
{
    [Table("Products")]
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();
            Orders = new List<Order>();
        }
        [Key]
        [DataType(DataType.Text)]
        public Guid Id { get; set; }
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string Name { get; set; } = default!;        
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public List<Order> Orders { get; set; }
    }
}