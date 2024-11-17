namespace AMSeCommerce.Communication.Request.Payment;

public class RequestCreateBoletoJson : RequestCreatePaymentJson
{
    public string Status { get; set; } = string.Empty;
    public RequestAdress Address { get; set; } = null!;
    public string ShippingAddress { get; set; } = string.Empty;

}