using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Quarterly_Sales.Models;

namespace Quarterly_Sales.Controllers
{
    public class EmployeeController : Controller
    {
        private SaleContext context { get; set; }
        public EmployeeController(SaleContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.FirstName).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(Employee);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = context.Employees.OrderBy(e => e.FirstName).ToList();
                return View(Employee);
            }
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.FirstName).ToList();
            return View();
        }
    }
}
