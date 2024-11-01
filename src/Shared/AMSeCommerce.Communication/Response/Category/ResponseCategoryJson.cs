namespace AMSeCommerce.Communication.Response.Category;

public  class ResponseCategoryJson
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public long? ParentCategoryId { get; set; }
}