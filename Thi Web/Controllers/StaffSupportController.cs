using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechShop.Controllers
{
    [Authorize(Roles = "Staff,Employee,Nhân viên")]
    [Route("Staff/Support/{action=Index}")]
    public class StaffSupportController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TawkDirectChatUrl = "https://tawk.to/chat/69bac14ebb7f0b1c337b2b54/1jk0o67bd";
            ViewBag.TawkDashboardUrl = "https://dashboard.tawk.to/";
            return View("~/Views/Staff/Support/Index.cshtml");
        }
    }
}
