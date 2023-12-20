using EmployeeAttenadance.Models;
using EmployeeAttendance.Utilities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Models
{
    public class AttendanceContext : DbContext
    {
        public AttendanceContext(DbContextOptions<AttendanceContext> options) : base(options) { }
        public DbSet<EmpDetails> EmpDetails { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<EmpSalaryDetails> EmpSalaryDetails { get; set; }
        public DbSet<EmpTotalSalary> EmpTotalSalary { get; set; }
        public DbSet<UserCredentials> UserCredentials { get; set; }
        public DbSet<XYZ> XYZ { get; set; }
    }
}