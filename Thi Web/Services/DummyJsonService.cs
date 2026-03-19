using System.Text.Json;

namespace TechShop.Services
{
    public class DummyProduct
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public double DiscountPercentage { get; set; }
        public double Rating { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Thumbnail { get; set; } = string.Empty;
        public List<string> Images { get; set; } = new();
        public decimal PriceVnd => Price * 25000;
        public decimal DiscountedPriceVnd =>
            Math.Round(PriceVnd * (1 - (decimal)DiscountPercentage / 100), 0);
    }

    public class DummyResult
    {
        public List<DummyProduct> Products { get; set; } = new();
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }

        // Tính đúng page hiện tại từ Skip/Limit
        public int CurrentPage =>
            Limit > 0 ? (Skip / Limit) + 1 : 1;

        // Tính đúng tổng số trang từ Total/Limit
        public int TotalPages =>
            Limit > 0 ? (int)Math.Ceiling((double)Total / Limit) : 1;
    }

    public interface IDummyJsonService
    {
        Task<DummyResult> GetByCategoryAsync(string category, int page = 1, int pageSize = 12);
        Task<DummyResult> SearchAsync(string keyword, int page = 1, int pageSize = 12);
        Task<DummyProduct?> GetDetailAsync(int id);
    }

    public class DummyJsonService : IDummyJsonService
    {
        private readonly HttpClient _http;
        private const string Base = "https://dummyjson.com";

        public static readonly Dictionary<string, string> TechCategories = new()
        {
            { "smartphones",        "Điện thoại"         },
            { "laptops",            "Laptop"             },
            { "tablets",            "Máy tính bảng"      },
            { "mobile-accessories", "Phụ kiện di động"   },
            { "mens-watches",       "Đồng hồ thông minh" }
        };

        public DummyJsonService(HttpClient http) => _http = http;

        public async Task<DummyResult> GetByCategoryAsync(string category, int page = 1, int pageSize = 12)
        {
            // Đảm bảo page >= 1
            if (page < 1) page = 1;
            int skip = (page - 1) * pageSize;
            var url = $"{Base}/products/category/{category}?limit={pageSize}&skip={skip}&select=id,title,description,price,discountPercentage,rating,stock,brand,category,thumbnail,images";
            return await FetchResult(url, pageSize);
        }

        public async Task<DummyResult> SearchAsync(string keyword, int page = 1, int pageSize = 12)
        {
            if (page < 1) page = 1;
            int skip = (page - 1) * pageSize;
            var url = $"{Base}/products/search?q={Uri.EscapeDataString(keyword)}&limit={pageSize}&skip={skip}";
            return await FetchResult(url, pageSize);
        }

        public async Task<DummyProduct?> GetDetailAsync(int id)
        {
            try
            {
                var json = await _http.GetStringAsync($"{Base}/products/{id}");
                return ParseProduct(JsonDocument.Parse(json).RootElement);
            }
            catch { return null; }
        }

        private async Task<DummyResult> FetchResult(string url, int pageSize)
        {
            try
            {
                var json = await _http.GetStringAsync(url);
                var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                int total = root.TryGetProperty("total", out var t) ? t.GetInt32() : 0;
                int skip = root.TryGetProperty("skip", out var s) ? s.GetInt32() : 0;
                int limit = root.TryGetProperty("limit", out var l) ? l.GetInt32() : pageSize;

                // Nếu API trả limit=0 thì dùng pageSize đã truyền vào
                if (limit == 0) limit = pageSize;

                var result = new DummyResult
                {
                    Total = total,
                    Skip = skip,
                    Limit = limit
                };

                if (root.TryGetProperty("products", out var products))
                    foreach (var item in products.EnumerateArray())
                        result.Products.Add(ParseProduct(item));

                return result;
            }
            catch
            {
                return new DummyResult { Limit = pageSize };
            }
        }

        private DummyProduct ParseProduct(JsonElement p)
        {
            var product = new DummyProduct();
            if (p.TryGetProperty("id", out var id)) product.Id = id.GetInt32();
            if (p.TryGetProperty("title", out var title)) product.Title = title.GetString() ?? "";
            if (p.TryGetProperty("description", out var desc)) product.Description = desc.GetString() ?? "";
            if (p.TryGetProperty("price", out var price)) product.Price = price.GetDecimal();
            if (p.TryGetProperty("discountPercentage", out var disc)) product.DiscountPercentage = disc.GetDouble();
            if (p.TryGetProperty("rating", out var rating)) product.Rating = rating.GetDouble();
            if (p.TryGetProperty("stock", out var stock)) product.Stock = stock.GetInt32();
            if (p.TryGetProperty("brand", out var brand)) product.Brand = brand.GetString() ?? "";
            if (p.TryGetProperty("category", out var cat)) product.Category = cat.GetString() ?? "";
            if (p.TryGetProperty("thumbnail", out var thumb)) product.Thumbnail = thumb.GetString() ?? "";
            if (p.TryGetProperty("images", out var imgs))
                foreach (var img in imgs.EnumerateArray())
                    product.Images.Add(img.GetString() ?? "");
            return product;
        }


    }
}