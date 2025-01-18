using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SampleCoreRestfulAPI.Models
{
    [Table("Orders")]
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
            Products = new List<Product>();
            OrderDate = DateTime.Now;
            OrderNumber = GenerateOrderNumber();
        }  

        [Key]
        [DataType(DataType.Text)]
        public Guid Id { get; set; }
      
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Currency)]
        public long OrderNumber { get; set; }

        [DataType(DataType.Currency)]
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public List<Product> Products { get; set; }
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }

        private long GenerateOrderNumber()
        {
            byte[] randomNumber = new byte[4];
            RandomNumberGenerator.Fill(randomNumber);
            return BitConverter.ToUInt32(randomNumber, 0) % 100000000;
        }
    }
}