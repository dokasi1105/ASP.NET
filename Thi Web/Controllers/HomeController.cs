namespace TechShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index(int? categoryId, string? search)
        {
            var categories = await _context.Categories.Include(c => c.Products).ToListAsync();

            if (!categoryId.HasValue && string.IsNullOrEmpty(search) && categories.Any())
            {
                categoryId = categories.First().Id;
            }

            IQueryable<Product> query = _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive);

            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            if (!string.IsNullOrEmpty(search))
                query = query.Where(p =>
                    p.Name.Contains(search) ||
                    (p.Description != null && p.Description.Contains(search)));

            var products = await query.ToListAsync();

            // Láº¥y sáº£n pháº©m yÃªu thÃ­ch náº¿u Ä‘Ã£ Ä‘Äƒng nháº­p
            List<Product> wishlistProducts = new List<Product>();
            if (User.Identity?.IsAuthenticated ?? false)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    wishlistProducts = await _context.Wishlists
                        .Include(w => w.Product)
                        .ThenInclude(p => p!.Category)
                        .Where(w => w.UserId == user.Id)
                        .Select(w => w.Product!)
                        .ToListAsync();
                }
            }

            // Láº¥y sáº£n pháº©m Ä‘ang giáº£m giÃ¡ (Promo)
            var promoProducts = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive && p.DiscountPrice.HasValue && p.DiscountPrice < p.Price)
                .OrderByDescending(p => p.CreatedAt)
                .Take(12)
                .ToListAsync();

            ViewBag.Categories = categories;
            ViewBag.SelectedCategory = categoryId;
            ViewBag.Search = search;
            ViewBag.WishlistProducts = wishlistProducts;
            ViewBag.PromoProducts = promoProducts;

            return View(products);
        }

        public async Task<IActionResult> FilterProducts(int? categoryId, string? search)
        {
            IQueryable<Product> query = _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive);

            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            if (!string.IsNullOrEmpty(search))
                query = query.Where(p =>
                    p.Name.Contains(search) ||
                    (p.Description != null && p.Description.Contains(search)));

            var products = await query.ToListAsync();
            return PartialView("_ProductList", products);
        }

        public IActionResult Privacy() => View();
        public IActionResult ChinhSach() => View();
        public IActionResult GioiThieu() => View();

        [HttpPost]
        public async Task<IActionResult> SubscribeNewsletter(string email)
        {
            if (string.IsNullOrEmpty(email)) return Json(new { success = false, message = "Email khÃ´ng há»£p lá»‡." });
            
            // Logically you would save to DB here
            
            try 
            {
                await _emailService.SendAsync(email, "Cáº£m Æ¡n báº¡n Ä‘Ã£ Ä‘Äƒng kÃ½ TechShop Newsletter!", 
                    "<h2>ChÃ o má»«ng báº¡n!</h2><p>TechShop Ä‘Ã£ ghi nháº­n Ä‘Äƒng kÃ½ cá»§a báº¡n. Báº¡n sáº½ nháº­n Ä‘Æ°á»£c nhá»¯ng thÃ´ng tin cÃ´ng nghá»‡ má»›i nháº¥t tá»« chÃºng tÃ´i.</p>");
                return Json(new { success = true, message = "ÄÄƒng kÃ½ thÃ nh cÃ´ng! Vui lÃ²ng kiá»ƒm tra email cá»§a báº¡n." });
            }
            catch (Exception ex)
            {
                // Tráº£ vá» lá»—i náº¿u khÃ´ng gá»­i Ä‘Æ°á»£c mail Ä‘á»ƒ ngÆ°á»i dÃ¹ng biáº¿t
                return Json(new { success = false, message = "KhÃ´ng thá»ƒ gá»­i email lÃºc nÃ y. " + ex.Message });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();
    }
}
