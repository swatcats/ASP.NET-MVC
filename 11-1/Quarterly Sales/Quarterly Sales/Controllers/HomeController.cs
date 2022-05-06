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
    public class HomeController : Controller
    {
        private SaleContext context { get; set; }
        public HomeController(SaleContext ctx)
        {
            context = ctx;
        }
        [HttpPost]
        public RedirectToActionResult Index(Employee employee)
        {
            if (employee.EmployeeId > 0)
            {
                return RedirectToAction("Index", new { id = employee.EmployeeId });
            }
            else
            {
                return RedirectToAction("Index", new { id = "" });
            }
        }
        [HttpGet]
        [Route("/Home/Index/{id}/")]
        public ViewResult Index(int id)
        {
            IQueryable<Sale> query = context.Sales.Include(s => s.Employee).OrderBy(s => s.Year);
            if (id > 0)
            {
                query = query.Where(s => s.EmployeeId == id);
            }
            var vm = new SaleListViewModel
            {
                Sales = query.ToList(),
                Employees = context.Employees.OrderBy(e => e.FirstName).ToList(),
                EmployeeId = id
            };
            return View(vm);
        }
        public IActionResult Index()
        {
            IQueryable<Sale> query = context.Sales.Include(s => s.Employee).OrderBy(s => s.Year);
            var vm = new SaleListViewModel
            {
                Sales = query.ToList(),
                Employees = context.Employees.OrderBy(e => e.FirstName).ToList(),
            };
            return View(vm);
        }
    }
}
