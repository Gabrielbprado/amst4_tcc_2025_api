namespace AMSeCommerce.Communication.Request.Order;

public class RequestOrderJson
{
    public long ProductId { get; set; } 
    public string Status { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
}