namespace AMSeCommerce.Communication.Request.Order;

public class RequestOrderJson
{
    public long ProductId { get; set; } 
    public string Status { get; set; } = string.Empty;
    public long AddressId { get; set; }
    public string ShippingAddress { get; set; } = string.Empty;
}