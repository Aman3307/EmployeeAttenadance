using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAttendance.Models
{
    public class EmpTotalSalary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TsId { get; set; }
        public decimal TotalSalary { get; set; }
        public int EmpId { get; set; }
        public int ModifiedById { get; set; }
        public string ModifiedByUsername { get; set; }
        public DateTime ModifiedOnDate { get; set; }
    }
}