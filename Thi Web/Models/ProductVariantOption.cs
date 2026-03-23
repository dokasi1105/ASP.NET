namespace TechShop.Models
{
    public class ProductVariantOption
    {
        public int Id { get; set; }
        public int ProductVariantGroupId { get; set; }
        public string Value { get; set; } = string.Empty; // Đen, 16GB, 1TB...

        public ProductVariantGroup? ProductVariantGroup { get; set; }
    }
}