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
        public async Task<IActionResult> Index(int? categoryId, string? search, string? brand, decimal? minPrice, decimal? maxPrice, string? sortOrder, string? priceRange)
        {
            // 1. Khởi tạo cây truy vấn trì hoãn (IQueryable)
            IQueryable<Product> query = _context.Products
               .Include(p => p.Category)
               .Where(p => p.IsActive);

            // 2. Chèn điều kiện lọc theo Danh mục
            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            // 3. Chèn điều kiện lọc theo Chuỗi tìm kiếm
            if (!string.IsNullOrEmpty(search))
            {
                string searchLower = search.ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(searchLower) ||
                                        (p.Description != null && p.Description.ToLower().Contains(searchLower)));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId);
                ViewBag.CurrentCat = categoryId;
            }

            // Xử lý bộ lọc giá thả xuống
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

            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(await query.ToListAsync());

            // 6. Xử lý logic Sắp xếp (Sorting)
            query = sortOrder switch
            {
                "price_asc" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                "name_asc" => query.OrderBy(p => p.Name),
                "name_desc" => query.OrderByDescending(p => p.Name),
                _ => query.OrderByDescending(p => p.CreatedAt) // Mặc định sắp xếp theo sản phẩm mới nhất
            };

            // 7. Thực thi câu lệnh SQL với AsNoTracking() để tối ưu hiệu năng đọc
            var products = await query.AsNoTracking().ToListAsync();

            // 8. Tải danh mục và thương hiệu cho thanh Sidebar
            ViewBag.Categories = await _context.Categories.AsNoTracking().Include(c => c.Products).ToListAsync();

            // 9. Lưu trạng thái tham số để duy trì hiển thị trên giao diện (Two-way binding feeling)
            ViewBag.SelectedCategory = categoryId;
            ViewBag.Search = search;
            ViewBag.SelectedBrand = brand;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.SortOrder = sortOrder;

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
