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
    public class SalesController : Controller
    {
        private SaleContext context { get; set; }
        public SalesController(SaleContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.FirstName).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Sale Sale)
        {
            if (ModelState.IsValid)
            {
                context.Sales.Add(Sale);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = context.Employees.OrderBy(e => e.FirstName).ToList();
                return View(Sale);
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
