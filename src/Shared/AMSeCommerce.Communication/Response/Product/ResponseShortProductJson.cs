using AMSeCommerce.Communication.Response.Category;

namespace AMSeCommerce.Communication.Response.Product;

public class ResponseShortProductJson
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string CategoryId { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public long ParentCategoryId { get; set; } 
    public ResponseCategoryJson Category { get; set; } = new();
}