using Microsoft.AspNetCore.Mvc;
using TicketApp.Models;

namespace TicketApp.Controllers
{
    public class IssueController : Controller
    {
        private IssueContext context { get; set; }
        public IActionResult Index()
        {
            return View();
        }
    }
}
