using EmployeeAttenadance;
using EmployeeAttendance.Models;
using EmployeeAttendance.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EmployeeAttendance.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AttendanceContext _dbContext;

        public EmployeeController(AttendanceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var employees = _dbContext.EmpDetails.FromSqlRaw("EXEC GetEmployeeList").ToList();
            return View(employees);
        }

        [HttpGet]
        [SessionAuthorization]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEmployee(EmpDetails employee)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var username = HttpContext.Session.GetString("Username");
            var modifiedOnDate = DateTime.Now;

            if (userId == null || string.IsNullOrEmpty(username))
            {
                return View("Error");
            }

            
            _dbContext.Database.ExecuteSqlRaw(
                "EXEC InsertOrUpdateEmpDetails @EmpId, @Name, @Dept, @MobileNo, @ModifiedById, @ModifiedByUsername, @ModifiedOnDate",
                new SqlParameter("@EmpId", employee.EmpId),
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Dept", employee.Dept),
                new SqlParameter("@MobileNo", employee.MobileNo),
                new SqlParameter("@ModifiedById", userId),
                new SqlParameter("@ModifiedByUsername", username),
                new SqlParameter("@ModifiedOnDate", modifiedOnDate));

            return RedirectToAction("Index");
        }

        [HttpGet]
        [SessionAuthorization]
        public IActionResult MarkAttendance(int id)
        {
            var employee = _dbContext.EmpDetails.FirstOrDefault(e => e.EmpId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult SaveAttendance(int empId, DateTime fromDate, DateTime toDate, string[] Status)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var username = HttpContext.Session.GetString("Username");
            var modifiedOnDate = DateTime.Now;

            if (userId == null || string.IsNullOrEmpty(username))
            {
                
                return View("Error");
            }

            foreach (var date in Enumerable.Range(0, 1 + toDate.Subtract(fromDate).Days)
                .Select(offset => fromDate.AddDays(offset)))
            {
                var status = Status[(date - fromDate).Days]; // Get the status for the current date

                // Execute the stored procedure to insert or update EmpAttendance with ModifiedBy information
                _dbContext.Database.ExecuteSqlRaw(
                    "exec InsertOrUpdateEmpAttendance @EmpId, @Date, @Status, @ModifiedById, @ModifiedByUsername, @ModifiedOnDate",
                    new SqlParameter("@EmpId", empId),
                    new SqlParameter("@Date", date),
                    new SqlParameter("@Status", status),
                    new SqlParameter("@ModifiedById", userId),
                    new SqlParameter("@ModifiedByUsername", username),
                    new SqlParameter("@ModifiedOnDate", modifiedOnDate)); // Set the current date and time
            }

            return RedirectToAction("Index");
        }



        [HttpGet]
        [SessionAuthorization]
        public IActionResult ModifySalary(int id)
        {
            var employee = _dbContext.EmpDetails.FirstOrDefault(e => e.EmpId == id);

            if (employee == null)
            {
                return NotFound();
            }

            var viewModel = new EmpDetailsViewModel
            {
                EmpDetails = employee,
                EmpSalaryDetails = new EmpSalaryDetails()
            };

            var totalSalary = _dbContext.EmpTotalSalary.FirstOrDefault(t => t.EmpId == id);

            if (totalSalary != null)
            {
                viewModel.EmpSalaryDetails.TsId = totalSalary.TsId;
                viewModel.EmpSalaryDetails.Basic = totalSalary.TotalSalary;
                
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SaveSalary(EmpDetailsViewModel viewModel)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var username = HttpContext.Session.GetString("Username");
            var modifiedOnDate = DateTime.Now;

            if (userId == null || string.IsNullOrEmpty(username))
            {
                
                return View("Error");
            }

            if (ModelState.IsValid)
            {
                
                decimal totalSalary = viewModel.EmpSalaryDetails.Basic + viewModel.EmpSalaryDetails.HRA + viewModel.EmpSalaryDetails.Others;

                // Update or insert EmpTotalSalary
                var tsIdParameter = new SqlParameter("@TsId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                
                _dbContext.Database.ExecuteSqlRaw(
                    "exec InsertOrUpdateEmpTotalSalary @EmpId, @Basic, @HRA, @Others, @ModifiedById, @ModifiedByUsername, @ModifiedOnDate, @TsId OUTPUT",
                    new SqlParameter("@EmpId", viewModel.EmpDetails.EmpId),
                    new SqlParameter("@Basic", viewModel.EmpSalaryDetails.Basic),
                    new SqlParameter("@HRA", viewModel.EmpSalaryDetails.HRA),
                    new SqlParameter("@Others", viewModel.EmpSalaryDetails.Others),
                    new SqlParameter("@ModifiedById", userId),
                    new SqlParameter("@ModifiedByUsername", username),
                    new SqlParameter("@ModifiedOnDate", modifiedOnDate),
                    tsIdParameter);

                
                var tsId = (int)tsIdParameter.Value;

                
                _dbContext.Database.ExecuteSqlRaw(
                    "exec InsertOrUpdateEmpSalaryDetails @TsId, @Basic, @HRA, @Others, @ModifiedById, @ModifiedByUsername, @ModifiedOnDate",
                    new SqlParameter("@TsId", tsId),
                    new SqlParameter("@Basic", viewModel.EmpSalaryDetails.Basic),
                    new SqlParameter("@HRA", viewModel.EmpSalaryDetails.HRA),
                    new SqlParameter("@Others", viewModel.EmpSalaryDetails.Others),
                    new SqlParameter("@ModifiedById", userId),
                    new SqlParameter("@ModifiedByUsername", username),
                    new SqlParameter("@ModifiedOnDate", modifiedOnDate));

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

    }
}
