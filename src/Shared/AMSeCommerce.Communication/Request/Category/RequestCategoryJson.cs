namespace AMSeCommerce.Communication.Request.Category;

public class RequestCategoryJson
{
    public string Description { get; set; } = string.Empty;
    public long? ParentCategoryId { get; set; }
}