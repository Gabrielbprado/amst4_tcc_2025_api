namespace AMSeCommerce.Communication.Request.BankAPI;

public class RequestSaveCardJson
{
    public string userId { get; set; } = string.Empty;
    public string cardToken { get; set; } = string.Empty;
}