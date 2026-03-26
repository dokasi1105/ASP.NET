using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TechShop.Data;
using TechShop.Models;

namespace TechShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICartService _cartService;

        public ProductController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            ICartService cartService)
        {
            _context = context;
            _userManager = userManager;
            _cartService = cartService;
        }

        // ===== INDEX =====
        public async Task<IActionResult> Index(
            int? category,
            string? search,
            string? priceRange,
            string? sortOrder,
            int page = 1)
        {
            int pageSize = 12;
            if (page < 1) page = 1;

            var query = _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .AsQueryable();

            // Lá»c theo CategoryId
            if (category.HasValue)
                query = query.Where(p => p.CategoryId == category.Value);

            // Lá»c theo search
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p =>
                    p.Name.Contains(search) ||
                    (p.Description != null && p.Description.Contains(search)));

            // Lá»c theo giÃ¡
            if (!string.IsNullOrEmpty(priceRange))
            {
                query = priceRange switch
                {
                    "under5" => query.Where(p => (p.DiscountPrice ?? p.Price) < 5_000_000),
                    "5to10" => query.Where(p => (p.DiscountPrice ?? p.Price) >= 5_000_000 && (p.DiscountPrice ?? p.Price) <= 10_000_000),
                    "10to15" => query.Where(p => (p.DiscountPrice ?? p.Price) > 10_000_000 && (p.DiscountPrice ?? p.Price) <= 15_000_000),
                    "over15" => query.Where(p => (p.DiscountPrice ?? p.Price) > 15_000_000),
                    _ => query
                };
            }

            // Sáº¯p xáº¿p
            query = sortOrder switch
            {
                "price_asc" => query.OrderBy(p => p.DiscountPrice ?? p.Price),
                "price_desc" => query.OrderByDescending(p => p.DiscountPrice ?? p.Price),
                "name_asc" => query.OrderBy(p => p.Name),
                _ => query.OrderByDescending(p => p.CreatedAt)
            };

            // PhÃ¢n trang
            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            if (totalPages < 1) totalPages = 1;
            if (page > totalPages) page = totalPages;

            var products = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Láº¥y categories tá»« DB cho sidebar
            var dbCategories = await _context.Categories
                .OrderBy(c => c.Name)
                .ToListAsync();

            ViewBag.Categories = dbCategories;
            ViewBag.Category = category;
            ViewBag.Search = search ?? "";
            ViewBag.SortOrder = sortOrder ?? "";
            ViewBag.PriceRange = priceRange ?? "";
            ViewBag.Page = page;
            ViewBag.TotalPages = totalPages;

            return View(products);
        }

        // ===== DETAIL =====
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Include(p => p.Specifications)
                .Include(p => p.WarrantyPackages)
                .Include(p => p.SelectedVariantOptions)
                    .ThenInclude(x => x.ProductVariantOption)
                        .ThenInclude(o => o!.ProductVariantGroup)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            ViewBag.Related = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == product.CategoryId && p.Id != id && p.IsActive)
                .Take(4)
                .ToListAsync();

            return View(product);
        }

        // ===== ADD TO CART =====
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(
            int productId,
            int quantity = 1,
            int warrantyId = 0,
            bool isTradeIn = false,
            List<int>? selectedOptionIds = null)
        {
            var product = await _context.Products
                .Include(p => p.WarrantyPackages)
                .Include(p => p.SelectedVariantOptions)
                    .ThenInclude(x => x.ProductVariantOption)
                        .ThenInclude(o => o!.ProductVariantGroup)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null) return NotFound();

            decimal finalPrice = product.DiscountPrice ?? product.Price;
            string extraOptions = "";

            selectedOptionIds ??= new();

            var validSelections = product.SelectedVariantOptions
                .Where(x => selectedOptionIds.Contains(x.ProductVariantOptionId))
                .Select(x => x.ProductVariantOption)
                .Where(x => x != null)
                .ToList();

            var requiredGroupNames = product.SelectedVariantOptions
                .Select(x => x.ProductVariantOption?.ProductVariantGroup?.Name)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct()
                .ToList();

            var selectedGroupNames = validSelections
                .Select(x => x!.ProductVariantGroup?.Name)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct()
                .ToList();

            if (requiredGroupNames.Any() && selectedGroupNames.Count < requiredGroupNames.Count)
            {
                TempData["Error"] = "Vui lÃ²ng chá»n Ä‘áº§y Ä‘á»§ biáº¿n thá»ƒ trÆ°á»›c khi thÃªm vÃ o giá» hÃ ng.";
                return RedirectToAction(nameof(Detail), new { id = productId });
            }

            if (validSelections.Any())
            {
                extraOptions += " [" + string.Join(" / ", validSelections.Select(x => x!.Value)) + "]";
            }

            if (warrantyId > 0)
            {
                var warranty = product.WarrantyPackages.FirstOrDefault(w => w.Id == warrantyId);
                if (warranty != null)
                {
                    finalPrice += warranty.AdditionalPrice;
                    extraOptions += $" [+ {warranty.PackageName}]";
                }
            }

            if (isTradeIn && product.IsTradeInEligible)
            {
                decimal tradeInDiscount = (product.MaxTradeInValue ?? 0) * 0.3m;
                finalPrice -= tradeInDiscount;
                extraOptions += " [Thu cÅ© Ä‘á»•i má»›i]";
            }

            _cartService.AddToCart(HttpContext.Session, new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name + extraOptions,
                Price = Math.Max(finalPrice, 0),
                Quantity = quantity,
                ImageUrl = product.ImageUrl
            });

            TempData["Success"] = $"ÄÃ£ thÃªm \"{product.Name}\" vÃ o giá» hÃ ng!";
            return RedirectToAction("Index", "Cart");
        }

        // ===== SO SÃNH =====
        [HttpPost]
        public async Task<IActionResult> AddToCompare(int productId)
        {
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null) return Json(new { success = false, message = "Sáº£n pháº©m khÃ´ng tá»“n táº¡i." });

            var compareListStr = HttpContext.Session.GetString("CompareList");
            var compareIds = string.IsNullOrEmpty(compareListStr)
                ? new List<int>()
                : JsonSerializer.Deserialize<List<int>>(compareListStr)!;

            if (compareIds.Contains(productId))
                return Json(new { success = true, count = compareIds.Count, message = "Sáº£n pháº©m Ä‘Ã£ náº±m trong so sÃ¡nh." });

            if (compareIds.Count >= 4)
                return Json(new { success = false, message = "Chá»‰ Ä‘Æ°á»£c so sÃ¡nh tá»‘i Ä‘a 4 sáº£n pháº©m." });

            if (compareIds.Count == 1)
            {
                var first = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == compareIds[0]);
                if (first != null && first.CategoryId != product.CategoryId)
                    return Json(new { success = false, message = "Chá»‰ so sÃ¡nh 2 sáº£n pháº©m cÃ¹ng danh má»¥c." });
            }

            compareIds.Add(productId);
            HttpContext.Session.SetString("CompareList", JsonSerializer.Serialize(compareIds));
            return Json(new { success = true, count = compareIds.Count, message = "ÄÃ£ thÃªm vÃ o danh sÃ¡ch so sÃ¡nh." });
        }

        [HttpPost]
        public IActionResult RemoveFromCompare(int productId)
        {
            var compareListStr = HttpContext.Session.GetString("CompareList");
            if (!string.IsNullOrEmpty(compareListStr))
            {
                var compareIds = JsonSerializer.Deserialize<List<int>>(compareListStr)!;
                compareIds.Remove(productId);
                HttpContext.Session.SetString("CompareList", JsonSerializer.Serialize(compareIds));
            }
            return RedirectToAction(nameof(Compare));
        }

        [HttpPost]
        public IActionResult ClearCompare()
        {
            HttpContext.Session.Remove("CompareList");
            return RedirectToAction(nameof(Compare));
        }

        public async Task<IActionResult> Compare()
        {
            var compareListStr = HttpContext.Session.GetString("CompareList");
            List<int> compareIds = string.IsNullOrEmpty(compareListStr)
                ? new List<int>()
                : JsonSerializer.Deserialize<List<int>>(compareListStr)!;

            var products = await _context.Products
                .Include(p => p.Specifications)
                .Where(p => compareIds.Contains(p.Id))
                .ToListAsync();

            return View(products);
        }

        // ===== WISHLIST =====
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleWishlist(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Json(new { success = false, message = "Vui lÃ²ng Ä‘Äƒng nháº­p!", redirectUrl = Url.Action("Login", "Account") });

            var productExists = await _context.Products
                .AnyAsync(p => p.Id == productId && p.IsActive);

            if (!productExists)
                return Json(new { success = false, message = "Sáº£n pháº©m khÃ´ng tá»“n táº¡i hoáº·c Ä‘Ã£ bá»‹ áº©n." });

            var existing = await _context.Wishlists
                .FirstOrDefaultAsync(w => w.UserId == user.Id && w.ProductId == productId);

            if (existing != null)
            {
                _context.Wishlists.Remove(existing);
                await _context.SaveChangesAsync();
                return Json(new { success = true, isAdded = false, message = "ÄÃ£ bá» yÃªu thÃ­ch." });
            }

            _context.Wishlists.Add(new Wishlist
            {
                UserId = user.Id,
                ProductId = productId
            });

            try
            {
                await _context.SaveChangesAsync();
                return Json(new { success = true, isAdded = true, message = "ÄÃ£ thÃªm vÃ o má»¥c yÃªu thÃ­ch." });
            }
            catch (DbUpdateException)
            {
                return Json(new { success = false, message = "KhÃ´ng thá»ƒ thÃªm vÃ o yÃªu thÃ­ch. Dá»¯ liá»‡u sáº£n pháº©m khÃ´ng há»£p lá»‡." });
            }
        }

        [Authorize]
        public async Task<IActionResult> Wishlist()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            var wishlists = await _context.Wishlists
                .Include(w => w.Product)
                .ThenInclude(p => p!.Category)
                .Where(w => w.UserId == user.Id)
                .Select(w => w.Product)
                .ToListAsync();

            return View(wishlists);
        }

        [HttpGet]
        public async Task<IActionResult> CompareQuick(int currentId, int otherId)
        {
            var current = await _context.Products
                .Include(p => p.Specifications)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == currentId);
            var other = await _context.Products
                .Include(p => p.Specifications)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == otherId);
            if (current == null || other == null)
                return Content("<div class='alert alert-danger'>KhÃ´ng tÃ¬m tháº¥y sáº£n pháº©m.</div>", "text/html");
            if (current.CategoryId != other.CategoryId)
                return Content("<div class='alert alert-warning'>Chá»‰ so sÃ¡nh 2 sáº£n pháº©m cÃ¹ng danh má»¥c.</div>", "text/html");
            var allSpecs = current.Specifications.Select(s => s.SpecName)
                .Union(other.Specifications.Select(s => s.SpecName))
                .Distinct()
                .ToList();

            ViewBag.AllSpecs = allSpecs;
            ViewBag.Current = current;
            ViewBag.Other = other;
            return PartialView("_CompareQuick");
        }

        [HttpGet]
        public async Task<IActionResult> SearchProducts(string term)
        {
            if (string.IsNullOrWhiteSpace(term)) return Json(new List<object>());

            var results = await _context.Products
                .Where(p => p.IsActive && p.Name.Contains(term))
                .Take(10)
                .Select(p => new {
                    id = p.Id,
                    name = p.Name,
                    price = p.Price.ToString("N0") + " â‚«",
                    image = p.ImageUrl ?? "https://via.placeholder.com/50",
                    categoryId = p.CategoryId
                })
                .ToListAsync();

            return Json(results);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCompareAjax(int productId)
        {
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null) return Json(new { success = false, message = "Sáº£n pháº©m khÃ´ng tá»“n táº¡i." });

            var compareListStr = HttpContext.Session.GetString("CompareList");
            var compareIds = string.IsNullOrEmpty(compareListStr)
                ? new List<int>()
                : JsonSerializer.Deserialize<List<int>>(compareListStr)!;

            if (compareIds.Contains(productId))
                return Json(new { success = false, message = "Sáº£n pháº©m Ä‘Ã£ cÃ³ trong danh sÃ¡ch so sÃ¡nh." });

            if (compareIds.Count >= 4)
                return Json(new { success = false, message = "Chá»‰ Ä‘Æ°á»£c so sÃ¡nh tá»‘i Ä‘a 4 sáº£n pháº©m." });

            if (compareIds.Count > 0)
            {
                var firstId = compareIds[0];
                var first = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == firstId);
                if (first != null && first.CategoryId != product.CategoryId)
                    return Json(new { success = false, message = "Chá»‰ Ä‘Æ°á»£c so sÃ¡nh cÃ¡c sáº£n pháº©m cÃ¹ng danh má»¥c." });
            }

            compareIds.Add(productId);
            HttpContext.Session.SetString("CompareList", JsonSerializer.Serialize(compareIds));
            return Json(new { success = true, count = compareIds.Count, message = "ÄÃ£ thÃªm vÃ o so sÃ¡nh." });
        }
    }
}