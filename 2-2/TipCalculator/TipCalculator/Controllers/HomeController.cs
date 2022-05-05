using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TipCalculator.Models;

namespace TipCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.fifteenPercentTipValue = 0;
            ViewBag.twentyPercentTipValue = 0;
            ViewBag.twentyFivePercentTipValue = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Index(TipCalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.fifteenPercentTipValue = model.CalculateTipValue(15);
                ViewBag.twentyPercentTipValue = model.CalculateTipValue(20);
                ViewBag.twentyFivePercentTipValue = model.CalculateTipValue(25);
            }
            else
            {
                ViewBag.fifteenPercentTipValue = 0;
                ViewBag.twentyPercentTipValue = 0;
                ViewBag.twentyFivePercentTipValue = 0;
            }
            return View(model);
        }
    }
}


