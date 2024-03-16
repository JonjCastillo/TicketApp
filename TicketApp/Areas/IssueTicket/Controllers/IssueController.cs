using Microsoft.AspNetCore.Mvc;

namespace TicketApp.Areas.IssueTicket.Controllers
{
    public class IssueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
