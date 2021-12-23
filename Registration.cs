using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpAssignment2.Models
{
    public class Registration
    {
        [Key]
        public int profileId { get; set; }

        [Required(ErrorMessage ="Enter street address")]
        public string address1 { get; set; }
        [Required(ErrorMessage = "Enter address")]
        public string address2 { get; set; }
        [Required(ErrorMessage = "Enter Postal Code")]
        public string postalCode { get; set; }
        [Required(ErrorMessage = "Enter phone number")]
        public int phoneNumber { get; set; }
        [ForeignKey("User")]
        public int userId { get; set; }
        public virtual User User { get; set; }

    }
}
