namespace AMSeCommerce.Communication.Request.Payment;

public class RequestPaymentPayer
{
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public RequestIdentification RequestIdentification { get; set; }
}