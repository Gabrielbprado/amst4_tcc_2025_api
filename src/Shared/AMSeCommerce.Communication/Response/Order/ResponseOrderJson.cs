using AMSeCommerce.Communication.Response.Product;

namespace AMSeCommerce.Communication.Response.Order;

public class ResponseOrderJson
{

    public long ProductId { get; set; }
    public List<ResponseProductJson> Product { get; set; } = null!;
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
    public string? BillingAddress { get; set; }
}