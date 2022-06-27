using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using project.Models;

namespace project.Controllers
{
    public class EmployeeController : Controller
    {
        public DatabaseContext _context;

        public EmployeeController(DatabaseContext context)
        {
            _context = context;
        }

        public ViewResult Signup()
        {
            return View();
        }

        public ViewResult Login()
        {
            return View();
        }
        public ViewResult Dashboard()
        {
            return View();
        }
        public ViewResult FetchData()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }
        public ViewResult Edit()
        {
            return View();
        }

        public IActionResult Read()
        {
            var employees = _context.Employees.ToList();
            return View(employees);

        }
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(Employee e)
        {
            if (ModelState.IsValid)
            {


                var em = new Employee()
                {
                    Name = e.Name,
                    Phone = e.Phone,
                    Department = e.Department,


                };
                _context.Employees.Add(em);

                _context.SaveChanges();
                TempData["msg"] = "saved";
                return RedirectToAction("Read");

            }
            else
            {
                TempData["error"] = "some error has occured";
                return View();
            }
        }

        public IActionResult delete(int id)
        {
            var em = _context.Employees.SingleOrDefault(e => e.Id == id);
            _context.Employees.Remove(em);
            _context.SaveChanges();
            TempData["msg"] = "succesfull";
            return RedirectToAction("Read");


        }
        public IActionResult EditEmployee(int id)
        {
            var e = _context.Employees.SingleOrDefault(em => em.Id == id);
            _context.Employees.Remove(e);
            return View();
        }
        [HttpPost]
        public IActionResult EditEmployee(Employee e)
        {
            if (ModelState.IsValid)
            {



                _context.Employees.Update(e);

                _context.SaveChanges();
                TempData["msg"] = "Update Saved";
                return RedirectToAction("Read");

            }
            else
            {
                TempData["error"] = "some error has occured";
                return View();
            }
        }
    }

}
   


    

