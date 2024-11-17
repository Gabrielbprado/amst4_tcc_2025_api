namespace AMSeCommerce.Communication.Response.Payment;

public class ResponseBoletoJson
{
    public long TransactionId { get; set; } 
    public string TicketUrl { get; set; } = string.Empty;

}