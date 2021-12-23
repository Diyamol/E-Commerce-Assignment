using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CSharpAssignment2.Models
{
    public class Status
    {
        [Key]
        public int statusId { get; set; }
        public string status { get; set; }
    }
}
