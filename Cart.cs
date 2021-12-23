using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpAssignment2.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }

        public string productName { get; set; }
        public string status { get; set; }
        [ForeignKey("User")]
        public int userId { get; set; }

        public virtual User User { get; set; }
        [ForeignKey("Product")]
        public int productId { get; set; }
        public virtual Products Product { get; set; }
    }
}
