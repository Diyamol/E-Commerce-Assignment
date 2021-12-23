using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpAssignment2.Models
{
    public class OrderDetail
    {
        [Key]
        public int orderDetailsId { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        [ForeignKey("Products")]
        public int productId { get; set; }
        public virtual Products Products { get; set; }
        [ForeignKey("Order")]
        public int orderId { get; set; }
        public virtual Order order { get; set; }
    }
}
