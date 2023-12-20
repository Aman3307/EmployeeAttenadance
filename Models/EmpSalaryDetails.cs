using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAttendance.Models
{
    public class EmpSalaryDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SdId { get; set; }
        public decimal Basic { get; set; }
        public decimal HRA { get; set; }
        public decimal Others { get; set; }
        public DateTime EntryDate { get; set; }
        public int TsId { get; set; }
        public int ModifiedById { get; set; }
        public string ModifiedByUsername { get; set; }
        public DateTime ModifiedOnDate { get; set; }
    }
}