using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketApp.Models;

namespace TicketApp.Controllers
{
    public class IssueController : Controller
    {
        private IssueContext context { get; set; }

        public IssueController(IssueContext ctx)
        {
            context = ctx;
        }

        public IActionResult Detail(int id)
        {
            var currentIssue = context.Issues
                .Include(currentIssue => currentIssue.Priority)
                .Include(currentIssue => currentIssue.Status)
                .FirstOrDefault(i => i.issueID == id);
            return View(currentIssue);
        }
    }
}
