using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechShop.Data;
using TechShop.Models;
using TechShop.ViewModels.Admin;

namespace TechShop.Controllers
{
    // ================================================================
    // ADMIN PRODUCT CONTROLLER
    // ================================================================
    [Authorize(Roles = "Staff,Employee,Nhân viên")]
    [Route("Staff/Product/{action=Index}")]
    public class StaffProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StaffProductController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index(int? categoryId)
        {
            var q = _context.Products.Include(p => p.Category).AsQueryable();
            if (categoryId.HasValue)
                q = q.Where(p => p.CategoryId == categoryId.Value);

            var products = await q.ToListAsync();

            ViewBag.Categories = await _context.Categories
                .Include(c => c.Products)
                .OrderBy(c => c.Name)
                .ToListAsync();

            ViewBag.SelectedCategory = categoryId;
            return View("~/Views/Staff/Product/Index.cshtml", products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.VariantGroups = await _context.ProductVariantGroups
                .Include(g => g.Options)
                .Where(g => g.IsActive)
                .OrderBy(g => g.SortOrder)
                .ToListAsync();

            return View("~/Views/Staff/Product/Create.cshtml", new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model, List<int> selectedOptionIds)
        {
            ModelState.Remove("Category");
            ModelState.Remove("SelectedVariantOptions");

            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.SelectedVariantOptions = selectedOptionIds
                    .Distinct()
                    .Select(id => new ProductVariantSelection
                    {
                        ProductVariantOptionId = id
                    }).ToList();

                _context.Products.Add(model);
                await _context.SaveChangesAsync();

                TempData["Success"] = "ThÃªm sáº£n pháº©m thÃ nh cÃ´ng!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.VariantGroups = await _context.ProductVariantGroups
                .Include(g => g.Options)
                .Where(g => g.IsActive)
                .OrderBy(g => g.SortOrder)
                .ToListAsync();

            return View("~/Views/Staff/Product/Create.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products
                .Include(p => p.SelectedVariantOptions)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.VariantGroups = await _context.ProductVariantGroups
                .Include(g => g.Options)
                .Where(g => g.IsActive)
                .OrderBy(g => g.SortOrder)
                .ToListAsync();

            ViewBag.SelectedOptionIds = product.SelectedVariantOptions
                .Select(x => x.ProductVariantOptionId)
                .ToList();

            return View("~/Views/Staff/Product/Edit.cshtml", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product model, List<int> selectedOptionIds)
        {
            if (id != model.Id) return NotFound();

            ModelState.Remove("Category");
            ModelState.Remove("SelectedVariantOptions");

            if (ModelState.IsValid)
            {
                var existingSelections = await _context.ProductVariantSelections
                    .Where(x => x.ProductId == model.Id)
                    .ToListAsync();

                _context.ProductVariantSelections.RemoveRange(existingSelections);

                model.SelectedVariantOptions = selectedOptionIds
                    .Distinct()
                    .Select(optionId => new ProductVariantSelection
                    {
                        ProductId = model.Id,
                        ProductVariantOptionId = optionId
                    }).ToList();

                _context.Products.Update(model);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Cáº­p nháº­t sáº£n pháº©m thÃ nh cÃ´ng!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.VariantGroups = await _context.ProductVariantGroups
                .Include(g => g.Options)
                .Where(g => g.IsActive)
                .OrderBy(g => g.SortOrder)
                .ToListAsync();

            ViewBag.SelectedOptionIds = selectedOptionIds;

            return View("~/Views/Staff/Product/Edit.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            if (product != null) { _context.Products.Remove(product); await _context.SaveChangesAsync(); }
            TempData["Success"] = "ÄÃ£ xÃ³a sáº£n pháº©m.";
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateImageUrl(int productId, string imageUrl)
        {
            // 1. Cáº­p nháº­t Database
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return Json(new { success = false, message = "KhÃ´ng tÃ¬m tháº¥y sáº£n pháº©m." });

            product.ImageUrl = imageUrl;
            await _context.SaveChangesAsync();

            // 2. Cáº­p nháº­t trá»±c tiáº¿p vÃ o mÃ£ nguá»“n ApplicationDbContext.cs (Seed Data)
            try
            {
                // ÄÆ°á»ng dáº«n tuyá»‡t Ä‘á»‘i tá»›i file context
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "ApplicationDbContext.cs");
                
                if (System.IO.File.Exists(filePath))
                {
                    string[] lines = await System.IO.File.ReadAllLinesAsync(filePath);
                    bool found = false;

                    for (int i = 0; i < lines.Length; i++)
                    {
                        // TÃ¬m dÃ²ng chá»©a Product cÃ³ Id tÆ°Æ¡ng á»©ng
                        if (lines[i].Contains($"Id = {productId},") && lines[i].Contains("new Product"))
                        {
                            // Thay tháº¿ giÃ¡ trá»‹ cá»§a ImageUrl = "..."
                            lines[i] = System.Text.RegularExpressions.Regex.Replace(
                                lines[i], 
                                @"ImageUrl\s*=\s*""[^""]*""", 
                                $@"ImageUrl = ""{imageUrl}"""
                            );
                            found = true;
                            break;
                        }
                    }

                    if (found)
                    {
                        await System.IO.File.WriteAllLinesAsync(filePath, lines);
                    }
                }
            }
            catch (Exception ex)
            {
                // Náº¿u lá»—i cáº­p nháº­t code thÃ¬ váº«n bÃ¡o thÃ nh cÃ´ng á»Ÿ DB nhÆ°ng kÃ¨m cáº£nh bÃ¡o lá»—i file
                return Json(new { success = true, message = "ÄÃ£ lÆ°u DB nhÆ°ng lá»—i cáº­p nháº­t file code: " + ex.Message });
            }

            return Json(new { success = true, message = "ÄÃ£ cáº­p nháº­t hÃ¬nh áº£nh vÃ o cáº£ Database vÃ  Source Code!" });
        }
    }


    // ================================================================
    // ADMIN CATEGORY CONTROLLER
    // ================================================================
    [Authorize(Roles = "Staff,Employee,Nhân viên")]
    [Route("Staff/Category/{action=Index}")]
    public class StaffCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StaffCategoryController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.Include(c => c.Products).ToListAsync();
            return View("~/Views/Staff/Category/Index.cshtml", categories);
        }

        [HttpGet]
        public IActionResult Create()
            => View("~/Views/Staff/Category/Create.cshtml", new Category());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category model)
        {
            ModelState.Remove("Products");
            if (ModelState.IsValid)
            {
                _context.Categories.Add(model);
                await _context.SaveChangesAsync();
                TempData["Success"] = "ThÃªm danh má»¥c thÃ nh cÃ´ng!";
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Staff/Category/Create.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Category? category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            return View("~/Views/Staff/Category/Edit.cshtml", category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category model)
        {
            if (id != model.Id) return NotFound();
            ModelState.Remove("Products");
            if (ModelState.IsValid)
            {
                _context.Categories.Update(model);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Cáº­p nháº­t danh má»¥c thÃ nh cÃ´ng!";
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Staff/Category/Edit.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Category? category = await _context.Categories.FindAsync(id);
            if (category != null) { _context.Categories.Remove(category); await _context.SaveChangesAsync(); }
            TempData["Success"] = "ÄÃ£ xÃ³a danh má»¥c.";
            return RedirectToAction(nameof(Index));
        }
    }

    // ================================================================
    // ADMIN ORDER CONTROLLER
    // ================================================================
    [Authorize(Roles = "Staff,Employee,Nhân viên")]
    [Route("Staff/Order/{action=Index}")]
    public class StaffOrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StaffOrderController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.User)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
            return View("~/Views/Staff/Order/Index.cshtml", orders);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Order? order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return NotFound();
            return View("~/Views/Staff/Order/Detail.cshtml", order);
        }

        private int CalculateEarnedPoints(decimal totalAmount)
        {
            // vÃ­ dá»¥: 1 Ä‘iá»ƒm / 100.000
            return (int)Math.Floor(totalAmount / 100_000m);
        }
        private string GetTierByPoints(int points)
        {
            if (points >= 5000) return "Diamond";
            if (points >= 2000) return "Gold";
            if (points >= 500) return "Silver";
            return "Bronze";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return NotFound();
            var oldStatus = order.Status;
            order.Status = status;
            if (order.User != null)
            {
                // Náº¿u chuyá»ƒn sang Completed vÃ  chÆ°a award -> cá»™ng
                if (status == "Completed" && !order.LoyaltyPointsAwarded)
                {
                    int earned = CalculateEarnedPoints(order.TotalAmount);
                    int oldPoints = order.User.LoyaltyPoints;
                    string oldTier = order.User.MembershipTier;
                    order.User.LoyaltyPoints += earned;
                    order.User.MembershipTier = GetTierByPoints(order.User.LoyaltyPoints);
                    order.LoyaltyPointsAwarded = true;

                    // TODO: náº¿u báº¡n Ä‘Ã£ thÃªm SendMembershipUpgradeEmailAsync
                    // if (oldTier != order.User.MembershipTier && !string.IsNullOrEmpty(order.User.Email))
                    //     await _emailService.SendMembershipUpgradeEmailAsync(...);

                    TempData["Success"] = $"ÄÃ£ cáº­p nháº­t tráº¡ng thÃ¡i + cá»™ng {earned} Ä‘iá»ƒm (tá»« {oldPoints} âžœ {order.User.LoyaltyPoints}).";
                }
                // Náº¿u chuyá»ƒn sang Cancelled mÃ  Ä‘Ã£ award -> trá»«
                if (status == "Cancelled" && order.LoyaltyPointsAwarded)
                {
                    int earned = CalculateEarnedPoints(order.TotalAmount);
                    int oldPoints = order.User.LoyaltyPoints;

                    order.User.LoyaltyPoints = Math.Max(0, order.User.LoyaltyPoints - earned);
                    order.User.MembershipTier = GetTierByPoints(order.User.LoyaltyPoints);
                    order.LoyaltyPointsAwarded = false;

                    TempData["Success"] = $"ÄÃ£ há»§y Ä‘Æ¡n vÃ  trá»« láº¡i {earned} Ä‘iá»ƒm (tá»« {oldPoints} âžœ {order.User.LoyaltyPoints}).";
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Detail), new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmPOS(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null && order.Status == "Pending")
            {
                order.Status = "Processing"; // Hoáº·c "Paid" tÃ¹y báº¡n Ä‘áº·t tÃªn
                await _context.SaveChangesAsync();
                TempData["Success"] = "Ä Ã£ xÃ¡c nháº­n thanh toÃ¡n POS thÃ nh cÃ´ng!";
            }
            return RedirectToAction("Detail", new { id = orderId });
        }
    }
    // ================================================================
    // ADMIN DASHBOARD CONTROLLER
    // ================================================================
    [Authorize(Roles = "Staff,Employee,Nhân viên")]
    [Route("Staff/Dashboard/{action=Index}")]
    public class StaffDashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffDashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var completedOrders = _context.Orders.Where(o => o.Status == "Completed");

            var totalRevenue = await completedOrders.SumAsync(o => (decimal?)o.TotalAmount) ?? 0m;
            var totalOrders = await _context.Orders.CountAsync();
            var totalProducts = await _context.Products.CountAsync();

            var topProducts = await _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .Where(od => od.Order != null && od.Order.Status == "Completed" && od.Product != null)
                .GroupBy(od => od.Product!.Name)
                .Select(g => new TopProductItemViewModel
                {
                    ProductName = g.Key,
                    SoldQuantity = g.Sum(x => x.Quantity),
                    Revenue = g.Sum(x => x.Quantity * x.UnitPrice)
                })
                .OrderByDescending(x => x.SoldQuantity)
                .Take(5)
                .ToListAsync();

            var salesRatio = topProducts.Select(x => new SalesRatioItemViewModel
            {
                ProductName = x.ProductName,
                SoldQuantity = x.SoldQuantity
            }).ToList();

            var vm = new AdminDashboardViewModel
            {
                TotalRevenue = totalRevenue,
                TotalOrders = totalOrders,
                TotalProducts = totalProducts,
                TopProducts = topProducts,
                SalesRatio = salesRatio
            };

            return View("~/Views/Staff/Dashboard/Index.cshtml", vm);
        }
    }

    // ================================================================
    // ADMIN VARIANT CONTROLLER
    // ================================================================
    [Authorize(Roles = "Staff,Employee,Nhân viên")]
    [Route("Staff/Variant/{action=Index}")]
    public class StaffVariantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffVariantController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var groups = await _context.ProductVariantGroups
                .Include(g => g.Category)
                .Include(g => g.Options)
                .OrderBy(g => g.Category!.Name)
                .ThenBy(g => g.SortOrder)
                .ToListAsync();

            return View("~/Views/Staff/Variant/Index.cshtml", groups);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
            return View("~/Views/Staff/Variant/Create.cshtml", new AdminVariantCatalogViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminVariantCatalogViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
                return View("~/Views/Staff/Variant/Create.cshtml", model);
            }

            await UpsertGroupAsync(model.CategoryId, "MÃ u Sáº¯c", model.Colors, 1);
            await UpsertGroupAsync(model.CategoryId, "Dung LÆ°á»£ng", model.Capacities, 2);
            await UpsertGroupAsync(model.CategoryId, "NÃ¢ng Cáº¥p", model.Upgrades, 3);

            TempData["Success"] = "ÄÃ£ lÆ°u bá»™ biáº¿n thá»ƒ theo danh má»¥c.";
            return RedirectToAction(nameof(Index));
        }

        private async Task UpsertGroupAsync(int categoryId, string groupName, string? rawValues, int sortOrder)
        {
            var group = await _context.ProductVariantGroups
                .Include(g => g.Options)
                .FirstOrDefaultAsync(g => g.CategoryId == categoryId && g.Name == groupName);

            if (group == null)
            {
                group = new ProductVariantGroup
                {
                    CategoryId = categoryId,
                    Name = groupName,
                    SortOrder = sortOrder,
                    IsActive = true
                };
                _context.ProductVariantGroups.Add(group);
                await _context.SaveChangesAsync();
            }

            var values = (rawValues ?? "")
                .Split('/', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            // xÃ³a option cÅ© cá»§a group rá»“i add láº¡i theo dá»¯ liá»‡u admin nháº­p
            var oldOptions = await _context.ProductVariantOptions
                .Where(o => o.ProductVariantGroupId == group.Id)
                .ToListAsync();

            if (oldOptions.Any())
                _context.ProductVariantOptions.RemoveRange(oldOptions);

            await _context.SaveChangesAsync();

            var newOptions = values.Select((v, index) => new ProductVariantOption
            {
                ProductVariantGroupId = group.Id,
                Value = v,
                SortOrder = index + 1,
                ColorHex = groupName == "MÃ u Sáº¯c" ? GuessColorHex(v) : null,
                IsActive = true
            }).ToList();

            if (newOptions.Any())
            {
                _context.ProductVariantOptions.AddRange(newOptions);
                await _context.SaveChangesAsync();
            }
        }

        private string? GuessColorHex(string value)
        {
            var key = value.Trim().ToLowerInvariant();
            return key switch
            {
                "Ä‘en" => "#111111",
                "tráº¯ng" => "#f8fafc",
                "Ä‘á»" => "#ef4444",
                "xanh" => "#3b82f6",
                "xanh lÃ¡" => "#22c55e",
                "vÃ ng" => "#eab308",
                "báº¡c" => "#cbd5e1",
                "há»“ng" => "#ec4899",
                _ => null
            };
        }
    }
    //[Authorize(Roles = "Staff,Employee,Nhân viên")]
    //[Route("Staff/Variant/{action=Index}")]
    //public class StaffVariantController : Controller
    //{
    //    private readonly ApplicationDbContext _context;

    //    public StaffVariantController(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<IActionResult> Index()
    //    {
    //        var variants = await _context.ProductVariants
    //            .Include(v => v.Product)
    //            .Include(v => v.Values)
    //                .ThenInclude(vv => vv.ProductVariantOption)
    //                    .ThenInclude(o => o!.ProductVariantGroup)
    //            .OrderByDescending(v => v.Id)
    //            .ToListAsync();

    //        return View("~/Views/Staff/Variant/Index.cshtml", variants);
    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> Create()
    //    {
    //        await EnsureVariantCatalogSeededAsync();
    //        ViewBag.Products = await _context.Products.Where(p => p.IsActive).OrderBy(p => p.Name).ToListAsync();
    //        ViewBag.Options = await _context.ProductVariantOptions
    //            .Include(o => o.ProductVariantGroup)
    //            .OrderBy(o => o.ProductVariantGroup!.Name)
    //            .ThenBy(o => o.Value)
    //            .ToListAsync();

    //        ViewBag.OptionCategoryMap = await BuildOptionCategoryMapAsync();

    //        return View("~/Views/Staff/Variant/Create.cshtml", new ProductVariant());
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create(ProductVariant model, List<int> selectedOptionIds)
    //    {
    //        ModelState.Remove("Product");
    //        ModelState.Remove("Values");

    //        selectedOptionIds = selectedOptionIds?.Distinct().ToList() ?? new List<int>();
    //        if (!selectedOptionIds.Any())
    //            ModelState.AddModelError("", "Vui lÃ²ng chá»n Ã­t nháº¥t 1 thuá»™c tÃ­nh biáº¿n thá»ƒ.");

    //        if (!ModelState.IsValid)
    //        {
    //            await EnsureVariantCatalogSeededAsync();
    //            ViewBag.Products = await _context.Products.Where(p => p.IsActive).OrderBy(p => p.Name).ToListAsync();
    //            ViewBag.Options = await _context.ProductVariantOptions.Include(o => o.ProductVariantGroup).ToListAsync();
    //            ViewBag.OptionCategoryMap = await BuildOptionCategoryMapAsync();
    //            return View("~/Views/Staff/Variant/Create.cshtml", model);
    //        }

    //        var duplicateGroupIds = await _context.ProductVariantOptions
    //            .Where(o => selectedOptionIds.Contains(o.Id))
    //            .GroupBy(o => o.ProductVariantGroupId)
    //            .Where(g => g.Count() > 1)
    //            .Select(g => g.Key)
    //            .ToListAsync();
    //        if (duplicateGroupIds.Any())
    //        {
    //            ModelState.AddModelError("", "Má»—i nhÃ³m thuá»™c tÃ­nh chá»‰ Ä‘Æ°á»£c chá»n 1 giÃ¡ trá»‹.");
    //            await EnsureVariantCatalogSeededAsync();
    //            ViewBag.Products = await _context.Products.Where(p => p.IsActive).OrderBy(p => p.Name).ToListAsync();
    //            ViewBag.Options = await _context.ProductVariantOptions.Include(o => o.ProductVariantGroup).ToListAsync();
    //            ViewBag.OptionCategoryMap = await BuildOptionCategoryMapAsync();
    //            return View("~/Views/Staff/Variant/Create.cshtml", model);
    //        }

    //        model.Values = selectedOptionIds.Select(x => new ProductVariantValue
    //        {
    //            ProductVariantOptionId = x
    //        }).ToList();

    //        _context.ProductVariants.Add(model);
    //        await _context.SaveChangesAsync();

    //        TempData["Success"] = "ÄÃ£ thÃªm biáº¿n thá»ƒ sáº£n pháº©m.";
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private async Task EnsureVariantCatalogSeededAsync()
    //    {
    //        var blueprints = new Dictionary<string, string[]>
    //        {
    //            ["MÃ u sáº¯c"] = new[] { "Äen", "Tráº¯ng", "Báº¡c", "Xanh", "Äá»" },
    //            ["RAM"] = new[] { "8GB", "16GB", "32GB", "64GB" },
    //            ["SSD"] = new[] { "512GB", "1TB", "2TB", "4TB" },
    //            ["PhiÃªn báº£n"] = new[] { "Standard", "Plus", "Pro", "Pro Max" },
    //            ["Hiá»‡u nÄƒng"] = new[] { "CÆ¡ báº£n", "NÃ¢ng cao", "Cao cáº¥p" },
    //            ["Káº¿t ná»‘i"] = new[] { "Wired", "Wireless", "Bluetooth" }
    //        };

    //        foreach (var entry in blueprints)
    //        {
    //            var group = await _context.ProductVariantGroups
    //                .Include(g => g.Options)
    //                .FirstOrDefaultAsync(g => g.Name == entry.Key);

    //            if (group == null)
    //            {
    //                group = new ProductVariantGroup { Name = entry.Key };
    //                _context.ProductVariantGroups.Add(group);
    //                await _context.SaveChangesAsync();
    //            }

    //            var existingValues = group.Options.Select(x => x.Value).ToHashSet(StringComparer.OrdinalIgnoreCase);
    //            var missingValues = entry.Value
    //                .Where(v => !existingValues.Contains(v))
    //                .Select(v => new ProductVariantOption
    //                {
    //                    ProductVariantGroupId = group.Id,
    //                    Value = v
    //                })
    //                .ToList();

    //            if (missingValues.Any())
    //            {
    //                _context.ProductVariantOptions.AddRange(missingValues);
    //                await _context.SaveChangesAsync();
    //            }
    //        }
    //    }

    //    private async Task<Dictionary<int, List<int>>> BuildOptionCategoryMapAsync()
    //    {
    //        var products = await _context.Products.Include(p => p.Category).AsNoTracking().ToListAsync();
    //        var categories = products
    //            .Select(p => p.Category)
    //            .Where(c => c != null)
    //            .DistinctBy(c => c!.Id)
    //            .Select(c => c!)
    //            .ToList();

    //        var allCategoryIds = categories.Select(c => c.Id).ToList();
    //        var laptopIds = categories.Where(c => c.Name.Contains("Laptop", StringComparison.OrdinalIgnoreCase)).Select(c => c.Id).ToList();
    //        var pcPartIds = categories.Where(c => c.Name.Contains("Linh kiá»‡n", StringComparison.OrdinalIgnoreCase) || c.Name.Contains("á»” cá»©ng", StringComparison.OrdinalIgnoreCase)).Select(c => c.Id).ToList();
    //        var peripheralIds = categories.Where(c =>
    //                c.Name.Contains("MÃ n hÃ¬nh", StringComparison.OrdinalIgnoreCase) ||
    //                c.Name.Contains("Chuá»™t", StringComparison.OrdinalIgnoreCase) ||
    //                c.Name.Contains("BÃ n phÃ­m", StringComparison.OrdinalIgnoreCase) ||
    //                c.Name.Contains("Gháº¿", StringComparison.OrdinalIgnoreCase) ||
    //                c.Name.Contains("Tai nghe", StringComparison.OrdinalIgnoreCase) ||
    //                c.Name.Contains("Äiá»‡n thoáº¡i", StringComparison.OrdinalIgnoreCase))
    //            .Select(c => c.Id)
    //            .ToList();

    //        var groupMap = new Dictionary<string, List<int>>(StringComparer.OrdinalIgnoreCase)
    //        {
    //            ["MÃ u sáº¯c"] = allCategoryIds,
    //            ["RAM"] = laptopIds,
    //            ["SSD"] = laptopIds.Concat(pcPartIds).Distinct().ToList(),
    //            ["PhiÃªn báº£n"] = peripheralIds,
    //            ["Hiá»‡u nÄƒng"] = pcPartIds,
    //            ["Káº¿t ná»‘i"] = peripheralIds
    //        };

    //        var options = await _context.ProductVariantOptions.Include(o => o.ProductVariantGroup).ToListAsync();
    //        var result = new Dictionary<int, List<int>>();
    //        foreach (var option in options)
    //        {
    //            var groupName = option.ProductVariantGroup?.Name ?? "";
    //            result[option.Id] = groupMap.TryGetValue(groupName, out var ids) && ids.Any()
    //                ? ids
    //                : allCategoryIds;
    //        }

    //        return result;
    //    }
    //}
}