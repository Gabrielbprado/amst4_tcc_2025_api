namespace AMSeCommerce.Domain.Entities;

public class Category : BaseEntity
{
    public string? Description { get; set; }
    public long? ParentCategoryId { get; set; }

    public Category? ParentCategory { get; set; }
    public List<Category> SubCategories { get; set; } = new List<Category>();
    public List<Product> Products { get; set; } = new List<Product>();
}