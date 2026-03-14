namespace TechShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(ApplicationDbContext context, ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _cartService = cartService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = _cartService.GetCart(HttpContext.Session);
            if (!cart.Any()) return RedirectToAction("Index", "Cart");
            ViewBag.Cart = cart;
            ViewBag.Total = _cartService.GetTotal(HttpContext.Session);
            return View(new Order());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(Order model)
        {
            var cart = _cartService.GetCart(HttpContext.Session);
            if (!cart.Any()) return RedirectToAction("Index", "Cart");

            ModelState.Remove("User");
            ModelState.Remove("UserId");
            ModelState.Remove("OrderDetails");

            if (!ModelState.IsValid)
            {
                ViewBag.Cart = cart;
                ViewBag.Total = _cartService.GetTotal(HttpContext.Session);
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            var order = new Order
            {
                UserId = user.Id,
                FullName = model.FullName,
                Address = model.Address,
                City = model.City,
                PostalCode = model.PostalCode,
                TotalAmount = _cartService.GetTotal(HttpContext.Session),
                Status = "Pending",
                OrderDate = DateTime.Now,
                OrderDetails = cart.Select(c => new OrderDetail
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    UnitPrice = c.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            _cartService.ClearCart(HttpContext.Session);

            return RedirectToAction(nameof(Completed), new { id = order.Id });
        }

        public async Task<IActionResult> Completed(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        public async Task<IActionResult> MyOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");
            var orders = await _context.Orders
                .Where(o => o.UserId == user.Id)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
            return View(orders);
        }
    }
}
