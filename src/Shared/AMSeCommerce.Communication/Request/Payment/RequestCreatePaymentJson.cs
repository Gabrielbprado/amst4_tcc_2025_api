namespace AMSeCommerce.Communication.Request.Payment;

public abstract class RequestCreatePaymentJson
{
    public decimal TransactionAmount { get; set; }
    public string Description { get; set; } = string.Empty;
    public RequestPaymentPayer Payer { get; set; }
}