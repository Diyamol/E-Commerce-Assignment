using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CSharpAssignment2.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        [Required(ErrorMessage ="Enter Username")]
        public string username { get; set; }
        [Required(ErrorMessage ="Enter password")]
        public string password { get; set; }
        [Required(ErrorMessage ="Enter Confirm password")]
        public string confirmPassword { get; set; }
    }
}
