using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechShop.Data;

namespace TechShop.Controllers
{
    [Authorize(Roles = "Staff,Employee,Nhân viên")]
    [Route("Staff/Service/{action=Index}")]
    public class StaffServiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tickets = await _context.ServiceTickets.OrderByDescending(t => t.BookingDate).ToListAsync();
            return View("~/Views/Staff/Service/Index.cshtml", tickets);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var ticket = await _context.ServiceTickets.FindAsync(id);
            if (ticket != null)
            {
                ticket.Status = status;
                await _context.SaveChangesAsync();
                TempData["Success"] = "ÄÃ£ cáº­p nháº­t tráº¡ng thÃ¡i phiáº¿u dá»‹ch vá»¥.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}