namespace AMSeCommerce.Communication.Response.Home;
 
public class ResponseHomeSectionJson 
{
    public string Title { get; set; } = string.Empty;
    public long CategoryId { get; set; }
    public long ParentCategoryId { get; set; }
    public List<string> ImageUrls { get; set; } = new List<string>();
}