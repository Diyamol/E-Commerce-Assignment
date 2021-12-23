using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpAssignment2.Models
{
    public class ProductCartViewModel
    {
        [Key]
        public int productCartId { get; set; }
        public int productId { get; set; }
        
        public string productName { get; set; }
        
        public string productDescription { get; set; }
        
        public decimal price { get; set; }
        
        public int quantity { get; set; }

        public string imageName { get; set; }
        public int CartId { get; set; }

       
        public string status { get; set; }
       
        public int userId { get; set; }
        
        
    }
}
