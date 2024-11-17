namespace AMSeCommerce.Communication.Request.BankAPI;

public class RequestChangeStatus
{
    public long TransactionId { get; set; }
    public string Status { get; set; } = string.Empty;
    
}