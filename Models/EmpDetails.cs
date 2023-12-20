using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAttendance.Models
{
    public class EmpDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpId { get; set; } // Primary key

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // This column is auto-incremented
        public int Id { get; set; }

        public string Name { get; set; }
        public string Dept { get; set; }
        public string MobileNo { get; set; }
        public int ModifiedById{get; set; }
        public string ModifiedBYUsername { get; set; }
        public DateTime ModifiedOnDate { get; set; }
    }
}