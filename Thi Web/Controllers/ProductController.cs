namespace TechShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICartService _cartService;

        public ProductController(ApplicationDbContext context, ICartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        // Cập nhật phương thức Index trong ProductController.cs
        public async Task<IActionResult> Index(int? categoryId, string? search, string? priceRange, string? sortOrder)
        {
            // 1. Khởi tạo truy vấn
            IQueryable<Product> query = _context.Products.Include(p => p.Category).Where(p => p.IsActive);

            // 2. Lọc theo Danh mục
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            // 3. Lọc theo Chuỗi tìm kiếm
            if (!string.IsNullOrEmpty(search))
            {
                string searchLower = search.ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(searchLower) ||
                                         (p.Description != null && p.Description.ToLower().Contains(searchLower)));
            }

            // 4. Lọc theo mức giá (Dropdown)
            if (!string.IsNullOrEmpty(priceRange))
            {
                switch (priceRange)
                {
                    case "under5": query = query.Where(p => p.Price < 5000000); break;
                    case "5to10": query = query.Where(p => p.Price >= 5000000 && p.Price <= 10000000); break;
                    case "10to15": query = query.Where(p => p.Price > 10000000 && p.Price <= 15000000); break;
                    case "over15": query = query.Where(p => p.Price > 15000000); break;
                }
            }

            // 5. Sắp xếp (Sorting)
            query = sortOrder switch
            {
                "price_asc" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                "name_asc" => query.OrderBy(p => p.Name),
                _ => query.OrderByDescending(p => p.CreatedAt) // Mặc định mới nhất
            };

            // 6. THỰC THI CÂU LỆNH SQL (Phải để ở CÙNG, sau khi đã ráp xong mọi bộ lọc)
            var products = await query.AsNoTracking().ToListAsync();

            // 7. Tải danh mục cho thanh Sidebar
            ViewBag.Categories = await _context.Categories.AsNoTracking().ToListAsync();

            // 8. Lưu trạng thái để giữ giao diện UI không bị reset
            ViewBag.SelectedCategory = categoryId;
            ViewBag.CurrentCat = categoryId; // Biến này dùng cho thẻ hidden
            ViewBag.Search = search;
            ViewBag.SortOrder = sortOrder;
            ViewBag.PriceRange = priceRange; // Thêm biến này để giữ Select Dropdown

            return View(products);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            var related = await _context.Products
                .Where(p => p.CategoryId == product.CategoryId && p.Id != id && p.IsActive)
                .Take(4).ToListAsync();

            ViewBag.Related = related;
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var product = _context.Products.Find(productId);
            if (product == null) return NotFound();

            _cartService.AddToCart(HttpContext.Session, new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = quantity,
                ImageUrl = product.ImageUrl
            });

            TempData["Success"] = $"Đã thêm \"{product.Name}\" vào giỏ hàng!";
            return RedirectToAction("Index", "Cart");
        }
    }
}
