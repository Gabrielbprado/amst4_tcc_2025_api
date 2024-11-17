namespace AMSeCommerce.Communication.Response.Payment;

public class ResponseCardJson
{
    public long TransactionId { get; set; }
    public string Status { get; set; } = string.Empty;
}