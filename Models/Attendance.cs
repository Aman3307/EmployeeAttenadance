using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAttendance.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int EmpId { get; set; }

        public int ModifiedById { get; set; }
        public string ModifiedByUsername { get; set; }
        public DateTime ModifiedOnDate { get; set; }
    }
}