namespace AMSeCommerce.Communication.Response.Product;

public class ResponseProductJson
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public long CategoryId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}