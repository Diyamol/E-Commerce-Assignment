using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpAssignment2.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        
        public DateTime orderDate { get; set; }
       
        public decimal totalPrice { get; set; }
        [ForeignKey("User")]
        public int userId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Status")]
        public int statusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
