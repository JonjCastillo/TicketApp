using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TicketApp.Models;

namespace TicketApp.Controllers
{
    public class HomeController : Controller
    {
        private IssueContext context { get; set; }

        public HomeController(IssueContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var issues = context.Issues
                .Include(issues => issues.Priority)
                .Include(issues => issues.Status)
                .OrderBy(i => i.submitDate).ToList();
            return View(issues);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
