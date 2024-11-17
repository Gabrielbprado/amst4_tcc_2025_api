using Microsoft.AspNetCore.Http;

namespace AMSeCommerce.Communication.Request.Product;

public class RequestProductJson
{
    public long? ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public long CategoryId { get; set; }
    public List<IFormFile> Images { get; set; }
}