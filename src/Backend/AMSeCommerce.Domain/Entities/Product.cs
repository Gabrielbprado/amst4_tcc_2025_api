namespace AMSeCommerce.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public long CategoryId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;

    public Category Category { get; set; }
    public List<ProductImage> Images { get; set; } = new List<ProductImage>();
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}