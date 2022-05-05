using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using FAQ.Models;

namespace FAQ.Controllers
{
    public class HomeController : Controller
    {
        private FAQContext context { get; set; }
        public HomeController(FAQContext ctx)
        {
            context = ctx;
        }
        [Route("/home/index/topic/{topic}")]
        [Route("/home/index/category/{category}")]
        [Route("/home/index/topic/{topic}/category/{category}")]
        public IActionResult Index(string topic, string category)
        {
            ViewBag.Topics = context.Topics.OrderBy(t => t.Name).ToList();
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            var FAQs = context.FAQs.Include(FAQ => FAQ.Category).Include(FAQ => FAQ.Topic).OrderBy(FAQ => FAQ.FAQId).ToList();
            if (topic != null)
            {
                if (category != null)
                {
                    FAQs = context.FAQs.Include(FAQ => FAQ.Category).Include(FAQ => FAQ.Topic).Where(FAQ => FAQ.TopicId == topic).Where(FAQ => FAQ.CategoryId == category).OrderBy(FAQ => FAQ.FAQId).ToList();
                }
                else
                {
                    FAQs = context.FAQs.Include(FAQ => FAQ.Category).Include(FAQ => FAQ.Topic).Where(FAQ => FAQ.TopicId == topic).OrderBy(FAQ => FAQ.FAQId).ToList();
                }
            }
            else
            {
                if (category != null)
                {
                    FAQs = context.FAQs.Include(FAQ => FAQ.Category).Include(FAQ => FAQ.Topic).Where(FAQ => FAQ.CategoryId == category).OrderBy(FAQ => FAQ.FAQId).ToList();
                }
            }
            return View(FAQs);
        }
        public IActionResult Index()
        {
            ViewBag.Topics = context.Topics.OrderBy(t => t.Name).ToList();
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            var FAQs = context.FAQs.Include(FAQ => FAQ.Category).Include(FAQ => FAQ.Topic).OrderBy(FAQ => FAQ.FAQId).ToList();
            return View(FAQs);
        }
    }
}
