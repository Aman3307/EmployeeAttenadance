using Microsoft.AspNetCore.Mvc;
using EmployeeAttendance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using EmployeeAttendance.Utilities;
using System.Linq;

namespace EmployeeAttendance.Controllers
{
    public class UserController : Controller
    {
        private readonly AttendanceContext _dbContext;

        public UserController(AttendanceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserCredentials user)
        {
            if (ModelState.IsValid)
            {
                // Call your stored procedure for user registration
                _dbContext.Database.ExecuteSqlRaw("EXEC RegisterUser @Username, @Password",
                    new SqlParameter("@Username", user.Username),
                    new SqlParameter("@Password", user.Password));

                return RedirectToAction("Login");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Login(string intendedAction)
        {
            if (!string.IsNullOrEmpty(intendedAction))
            {
                HttpContext.Session.SetString("intendedAction", intendedAction);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserCredentials user)
        {
            if (ModelState.IsValid)
            {
                
                var authenticatedUser = _dbContext.UserCredentials
                    .SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);

                if (authenticatedUser != null)
                {
                    
                    HttpContext.Session.SetString("Username", authenticatedUser.Username);

                    
                    HttpContext.Session.SetInt32("UserId", authenticatedUser.UserId);

                     
                    var intendedAction = HttpContext.Session.GetString("intendedAction");
                    if (!string.IsNullOrEmpty(intendedAction))
                    {
                        return RedirectToAction(intendedAction);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Employee"); // Change to "Employee" controller
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(user);
        }

        public IActionResult Logout()
        {
            // Clear the session to log out
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
