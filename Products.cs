using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpAssignment2.Models
{
    public class Products
    {
        [Key]
        public int productId { get; set; }
        [Required(ErrorMessage = "Enter product Name")]
        public string productName { get; set; }
        [Required(ErrorMessage = "Enter description")]
        public string productDescription { get; set; }
        [Required(ErrorMessage = "Enter price")]
        public decimal price { get; set; }
        [Required(ErrorMessage = "Enter quantity")]
        public int quantity { get; set; }
        
        public string imageName { get; set; }
        [NotMapped]
        public IFormFile productImge { get; set; }
    }
}
