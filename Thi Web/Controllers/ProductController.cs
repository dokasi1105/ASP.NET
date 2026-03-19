namespace TechShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDummyJsonService _dummyJson;
        private readonly ICartService _cartService;

        public ProductController(IDummyJsonService dummyJson, ICartService cartService)
        {
            _dummyJson = dummyJson;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index(
            string? category,
            string? search,
            string? priceRange,
            string? sortOrder,
            int page = 1)
        {
            // Đảm bảo page hợp lệ
            if (page < 1) page = 1;

            string activeCategory = string.IsNullOrEmpty(category)
                ? "smartphones" : category;

            DummyResult result;

            if (!string.IsNullOrEmpty(search))
                result = await _dummyJson.SearchAsync(search, page, 12);
            else
                result = await _dummyJson.GetByCategoryAsync(activeCategory, page, 12);

            var products = result.Products;

            // Lọc giá (client-side)
            if (!string.IsNullOrEmpty(priceRange))
            {
                products = priceRange switch
                {
                    "under5" => products.Where(p => p.DiscountedPriceVnd < 5_000_000).ToList(),
                    "5to10" => products.Where(p => p.DiscountedPriceVnd >= 5_000_000 && p.DiscountedPriceVnd <= 10_000_000).ToList(),
                    "10to15" => products.Where(p => p.DiscountedPriceVnd > 10_000_000 && p.DiscountedPriceVnd <= 15_000_000).ToList(),
                    "over15" => products.Where(p => p.DiscountedPriceVnd > 15_000_000).ToList(),
                    _ => products
                };
            }

            // Sắp xếp
            products = sortOrder switch
            {
                "price_asc" => products.OrderBy(p => p.DiscountedPriceVnd).ToList(),
                "price_desc" => products.OrderByDescending(p => p.DiscountedPriceVnd).ToList(),
                "name_asc" => products.OrderBy(p => p.Title).ToList(),
                "rating" => products.OrderByDescending(p => p.Rating).ToList(),
                _ => products
            };

            // Truyền page/totalPages đúng từ API response
            int totalPages = result.Total > 0 && result.Limit > 0
      ? (int)Math.Ceiling((double)result.Total / 12.0)
      : 1;


            // Giới hạn totalPages hợp lý
            if (totalPages < 1) totalPages = 1;
            if (page > totalPages) page = totalPages;

            ViewBag.Categories = DummyJsonService.TechCategories;
            ViewBag.Category = activeCategory;
            ViewBag.Search = search ?? "";
            ViewBag.SortOrder = sortOrder ?? "";
            ViewBag.PriceRange = priceRange ?? "";
            ViewBag.Page = page;
            ViewBag.TotalPages = totalPages;

            return View(products);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var product = await _dummyJson.GetDetailAsync(id);
            if (product == null) return NotFound();

            var related = await _dummyJson.GetByCategoryAsync(product.Category, 1, 5);
            ViewBag.Related = related.Products.Where(p => p.Id != id).Take(4).ToList();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(
            int productId, string title,
            decimal priceVnd, string? thumbnail,
            int quantity = 1)
        {
            _cartService.AddToCart(HttpContext.Session, new CartItem
            {
                ProductId = productId,
                ProductName = title,
                Price = priceVnd,
                Quantity = quantity,
                ImageUrl = thumbnail
            });

            TempData["Success"] = $"Đã thêm \"{title}\" vào giỏ hàng!";
            return RedirectToAction("Index", "Cart");
        }
    }
}