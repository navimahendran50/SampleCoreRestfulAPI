using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCoreRestfulAPI.Models
{
    [Table("Customers")]
    public class Customer
    {
        public Customer()
        {
            Id = Guid.NewGuid();
            Orders = new List<Order>();
        }
        [Key]
        [DataType(DataType.Text)]
        public Guid Id { get; set; }
        [MaxLength(50)] 
        [DataType(DataType.Text)]
        public string Name { get; set; } = default!;

        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; } 
        [MaxLength(10)] 
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = default!;
        [MaxLength(50)] 
        [DataType(DataType.Text)]
        public string Address { get; set; } = default!;
        [MaxLength(15)] 
        [DataType(DataType.Text)]
        public string City { get; set; } = default!;
        [MaxLength(15)] 
        [DataType(DataType.Text)]
        public string State { get; set; } = default!;
        [MaxLength(6)] 
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; } = default!;
        [MaxLength(50)] 
        [DataType(DataType.Text)]
        public Guid? OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public List<Order>? Orders { get; set; }
    }
}