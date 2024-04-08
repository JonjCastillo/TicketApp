using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO.IsolatedStorage;
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

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Priorities = context.Priorities.OrderBy(p => p.PriorityName).ToList();
            ViewBag.Statuses = context.Statuses.OrderBy(s => s.StatusName).ToList();
            return View(new Issue());
        }

        [HttpPost]
        public IActionResult Add(Issue issue)
        {
            if (ModelState.IsValid)
            {
                context.Issues.Add(issue);
                context.SaveChanges();
                TempData["message"] = "Ticket submitted successfully!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = "Add";
                ViewBag.Priorities = context.Priorities.OrderBy(p => p.PriorityName).ToList();
                ViewBag.Statuses = context.Statuses.OrderBy(s => s.StatusName).ToList();
                return View(issue);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var issue = context.Issues.Find(id);
            ViewBag.Action = "Edit";
            ViewBag.Priorities = context.Priorities.OrderBy(p => p.PriorityName).ToList();
            ViewBag.Statuses = context.Statuses.OrderBy(s => s.StatusName).ToList();
            return View(new IssueViewModel()
            {
                StatusID = issue!.StatusID,
                PriorityID = issue!.PriorityID,
                issueID = issue!.issueID
            });
        }

        [HttpPost]
        public IActionResult Edit(int issueID, [Bind("issueID,StatusID,PriorityID")] IssueViewModel issue)
        {
            var currentIssue = context.Issues.Find(issueID);

            if (currentIssue == null)
            {
                return NotFound();
            }

            currentIssue.StatusID = issue.StatusID;
            currentIssue.PriorityID = issue.PriorityID;

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(currentIssue);
                    context.SaveChanges();
                    TempData["message"] = $"Ticket #{currentIssue.issueID} updated successfully";
                    return RedirectToAction("Index", "Home");
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }   
            }
            
            ViewBag.Action = "Edit";
            ViewBag.Priorities = context.Priorities.OrderBy(p => p.PriorityName).ToList();
            ViewBag.Statuses = context.Statuses.OrderBy(s => s.StatusName).ToList();
            return View(issue);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var issue = context.Issues.Find(id);
            return View(issue);
        }

        [HttpPost]
        public IActionResult Delete(Issue issue)
        {
            TempData["message"] = $"Ticket #{issue.issueID} deleted successfully";
            context.Issues.Remove(issue);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
