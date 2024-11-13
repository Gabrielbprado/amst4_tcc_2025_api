namespace AMSeCommerce.Communication.Request.Payment;

public class RequestCreatePixJson
{
    public decimal TransactionAmount { get; set; }
    public string Description { get; set; } = string.Empty;
    public RequestPaymentPayer Payer { get; set; }
    public string NotificationUrl { get; set; } = string.Empty;
}