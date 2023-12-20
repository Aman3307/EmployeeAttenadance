using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAttenadance.Models
{
    public class XYZ
    {
        [Key]
        public int Id { get; set; }
        public string Hi { get; set; }
        public string Hello { get; set; } 
    }
}
