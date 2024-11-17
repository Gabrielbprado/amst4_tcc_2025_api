namespace AMSeCommerce.Communication.Request.Payment;

public class RequestCreateCardPaymentJson : RequestCreatePaymentJson
{
    public string CardToken { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
}