using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TicketApp.Models;
//using System.Web.Mvc;

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
        public IActionResult Index(string? filterStatus, string? sortStatus)
        {
            var issues = context.Issues
                .Include(issues => issues.Priority)
                .Include(issues => issues.Status)
                .ToList();

            if (!string.IsNullOrEmpty(filterStatus) && filterStatus != "all")
            {
                issues = issues.Where(i => i.StatusID == filterStatus).ToList();
            }

            var ddl = new SelectList(
                context.Statuses,
                "StatusID",
                "StatusName",
                filterStatus
            );
            ViewData["StatusOptionsDDL"] = ddl.Append(new SelectListItem {
                Value = "all",
                Text = "All",
                Selected = string.IsNullOrEmpty(filterStatus) || filterStatus == "all"
            }); ;

            if (!string.IsNullOrEmpty(sortStatus))
            {
                if (sortStatus == "priority")
                {
                    issues = issues.OrderByDescending(i => i.Priority.PriorityID).ToList();
                }
                else if (sortStatus == "date")
                {
                    issues = issues.OrderByDescending(i => i.submitDate).ToList();
                }
            }


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
