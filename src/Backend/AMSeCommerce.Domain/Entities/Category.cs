namespace AMSeCommerce.Domain.Entities;

public class Category : BaseEntity
{
    public string? Description { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
    public List<ParentCategory> ParentCategories { get; set; } = new List<ParentCategory>();

}