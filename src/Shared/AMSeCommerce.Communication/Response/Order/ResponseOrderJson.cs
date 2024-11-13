namespace AMSeCommerce.Communication.Response.Order;

public class ResponseOrderJson
{
    
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
    public string? BillingAddress { get; set; }
}